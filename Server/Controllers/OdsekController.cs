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

        [Route("{id}/getSlucaj/{status}")]
        [HttpGet]
         public async Task<ActionResult> getSlucaj(int id, int status)
         {
            var slucajevi = await Context.Slucajevi
            .Include(p => p.Odsek)
            .Include(p => p.Radnik)
            .Where(p => p.Odsek.id==id)
            .Where(p => p.status==status)
            .ToListAsync();
            return Ok(slucajevi);
         }


    }
}