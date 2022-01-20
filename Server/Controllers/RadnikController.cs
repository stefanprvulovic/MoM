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

        [Route("getRadnik")]
        [HttpGet]
        public ActionResult get()
        {
            return Ok(Context.Radnici);
        }

        [Route("addRadnik")] // Dodaj radnika
        [HttpPost]
        public async Task<ActionResult> addRadnik([FromBody] Radnik radnik)
        {
            if (string.IsNullOrWhiteSpace(radnik.ime) && radnik.ime.Length>25)
            {
                return BadRequest("Podatak je pogrešno unet ili je predugačak.");
            }

             if (string.IsNullOrWhiteSpace(radnik.prezime) && radnik.ime.Length>50)
            {
                return BadRequest("Podatak je pogrešno unet ili je predugačak.");
            }

            if (radnik.brLegitimacije<100000)
            {
                return BadRequest("Pogrešan format legitimacije!");
            }

            if (radnik.pol!="M" && radnik.pol!="Ž")
            {
                return BadRequest("Pogrešno unet karakter za pol!");
            }

            if (radnik.godRodj<1950)
            {
                return BadRequest("Pogrešno uneta godina!");
            }

            try
            {
                Context.Radnici.Add(radnik);
                await Context.SaveChangesAsync();
                return Ok($"Radnik je uspešno dodat! Njegov ID je: {radnik.id}.");
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
                return BadRequest("Pogrešno unet ID!");
            
            try
            {
                var radnik = await Context.Radnici.FindAsync(id);
                int pom=radnik.brLegitimacije;
                Context.Radnici.Remove(radnik);
                await Context.SaveChangesAsync(); // cuvanje u bazi
                 return Ok($"Radnik sa legitimacijom {pom} je uspešno otpušten!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

    //kad metoda ima argumente, menja studente eksplcitno po argumentima {argument}, {argument}
}