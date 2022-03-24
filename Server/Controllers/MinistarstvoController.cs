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
    public class MinistarstvoController : ControllerBase
    {
        public MoMContext Context { get; set; }
        public MinistarstvoController(MoMContext context)
        {
            Context = context;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            try
            {
                return Ok(await Context.Ministarstva.Include(p => p.Odseci).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}