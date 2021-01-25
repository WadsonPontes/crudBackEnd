using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aprendendoAPI.Data;
using aprendendoAPI.Models;

namespace aprendendoAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class EstudoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<List<Estudo>>> Get([FromServices] DataContext context)
        {
            var estudos = await context.Estudos.ToListAsync();
            return estudos;
        }

        [HttpPost]
        [Route("editar")]
        public async Task<ActionResult<List<Estudo>>> Post(
            [FromServices] DataContext context,
            [FromBody]Estudo model)
        {
            if (ModelState.IsValid) {
                context.Estudos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}