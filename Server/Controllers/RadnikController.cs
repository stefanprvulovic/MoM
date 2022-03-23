using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace MoM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadnikController : ControllerBase
    {
        public MoMContext Context { get; set; }
        public RadnikController(MoMContext context)
        {
            Context=context;
        }

        [Route("getRadnikByName/{ime}/{prezime}")]
        [HttpGet]
        public ActionResult getRadnikByName(string ime, string prezime)
        {
            var radnik = Context.Radnici
                            .Where(p => p.ime==ime)
                            .Where(p => p.prezime==prezime);
            return Ok(radnik);
        }

        [Route("addRadnik/{ime}/{prezime}/{pol}/{brLegitimacije}/{godRodj}")] // Dodaj radnika
        [HttpPost]
        public async Task<ActionResult> addRadnik(string ime, string prezime, string pol,
        int brLegitimacije, int godRodj)
        {
            if (string.IsNullOrWhiteSpace(ime) && ime.Length>25)
            {
                return BadRequest("Podatak je pogrešno unet ili je predugačak.");
            }

             if (string.IsNullOrWhiteSpace(prezime) && prezime.Length>50)
            {
                return BadRequest("Podatak je pogrešno unet ili je predugačak.");
            }

            if (brLegitimacije<100000)
            {
                return BadRequest("Pogrešan format legitimacije!");
            }

            if (pol!="M" && pol!="Ž")
            {
                return BadRequest("Pogrešno unet karakter za pol!");
            }

            if (godRodj<1950)
            {
                return BadRequest("Pogrešno uneta godina!");
            }

            try
            {
                Radnik dodatRadnik = new Radnik();
                dodatRadnik.ime = ime;
                dodatRadnik.prezime = prezime;
                dodatRadnik.pol = pol;
                dodatRadnik.brLegitimacije = brLegitimacije;
                dodatRadnik.godRodj = godRodj;

                Context.Radnici.Add(dodatRadnik);
                await Context.SaveChangesAsync();
                return Ok($"Radnik je uspešno dodat! Njegov ID je: {dodatRadnik.id}.");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deleteRadnik/{id}")] // Otpusti radnika
        [HttpDelete]
        public async Task<ActionResult> deleteRadnik(int id)
        {
            if (id<=0)
            {
                return BadRequest("Pogrešno unet ID!");
            }
            
            try
            {
                var radnik = await Context.Radnici.FindAsync(id);
                Context.Radnici.Remove(radnik);
                await Context.SaveChangesAsync(); // cuvanje u bazi
                 return Ok("Radnik je uspešno otpušten!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("dodeliSlucaj/{radnikID}/{kodnoIme}")] // dodeli slucaj radniku
        [HttpPut]
        public async Task<ActionResult> dodeliSlucaj(int radnikID, string kodnoIme)
        {
            var slucaj = Context.Slucajevi.Where(p => p.kodnoIme==kodnoIme).FirstOrDefault();
            var radnik = Context.Radnici.Where(p => p.id==radnikID).FirstOrDefault();
            slucaj.Radnik=radnik;
            await Context.SaveChangesAsync();
            return Ok($"Uspešno je dodeljen radnik slucaju {slucaj.kodnoIme}.");
        }


    }
}