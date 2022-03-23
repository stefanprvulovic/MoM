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
    public class SlucajController : ControllerBase
    {
        public MoMContext Context { get; set; }
        public SlucajController(MoMContext context)
        {
            Context=context;
        }

        [Route("addSlucaj/{odsekID}")] // Dodaj slucaj
        [HttpPost]
        public async Task<ActionResult> addSlucaj([FromBody] Slucaj s, int odsekID)
        {
            if (s.nivoPov!="poverljivo" && s.nivoPov!="ograničen pristup"
                && s.nivoPov!="javno")
                {
                    return BadRequest("Nevalidan unos za nivo poverljivosti!");
                }
            
            if (s.opis.Length>150)
            {
                return BadRequest("Opis je predugačak!");
            }

            try
            {
                 var dodatSlucaj=new Slucaj();
                 dodatSlucaj.kodnoIme=s.kodnoIme;
                 dodatSlucaj.status=1; // defaultno se status postavlja na 1-u procesu resavanja
                 dodatSlucaj.opis=s.opis;
                 dodatSlucaj.nivoPov=s.nivoPov;
                 var odsek=await Context.Odseci.FindAsync(odsekID);
                 dodatSlucaj.Odsek=odsek;
                 var prazanRadnik=new Radnik();
                 dodatSlucaj.Radnik=prazanRadnik;
                 Context.Slucajevi.Add(dodatSlucaj);
                 await Context.SaveChangesAsync();
                 return Ok($"Slučaj je uspešno dodat! Njegov ID je: {dodatSlucaj.id}."); 
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [Route("editStatus/{kodnoIme}")] // Promeni status slucaja sa zadatim kodnim imenom
        [HttpPut]
        public async Task<ActionResult> editStatus(string kodnoIme)
        {
            try
            {
                var slucaj = Context.Slucajevi.Where(p => p.kodnoIme==kodnoIme).FirstOrDefault();

                if (slucaj!=null)
                {
                    if (slucaj.status==0)
                    {
                        slucaj.status=1;
                    }
                    else
                    {
                        slucaj.status=0;
                    }
                    await Context.SaveChangesAsync();
                    return Ok($"Uspešno je promenjen status slučaja sa kodnim imenom {slucaj.kodnoIme}.");
                }
                else
                {
                    return BadRequest("Ne postoji slučaj sa ovim kodnim imenom!");
                }
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