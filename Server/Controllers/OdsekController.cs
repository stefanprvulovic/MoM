using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace MoM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdsekController : ControllerBase
    {
        public MoMContext Context { get; set; }
        public OdsekController(MoMContext context)
        {
            Context=context;
        }

        [Route("getOdsek")]
        [HttpGet]
        public async Task<ActionResult> getOdsek()
        {
            try
            {
                return Ok(await Context.Odseci.Select(p => new { p.id, p.ime }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getSlucaj/{imeOdseka}/{status}")]
        [HttpGet]
         public async Task<ActionResult> getSlucaj(string imeOdseka, int status)
         {
            var slucajevi = await Context.Slucajevi
            .Include(p => p.Odsek)
            .Where(p => p.Odsek.ime==imeOdseka)
            .Where(p => p.status==status)
            .ToListAsync();
            return Ok(slucajevi);
         }


    }
}