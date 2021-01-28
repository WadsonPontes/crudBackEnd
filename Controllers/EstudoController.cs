using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
        public async Task<ActionResult<List<Estudo>>> Listar([FromServices] DataContext context)
        {
            var estudos = await context.Estudos
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            return estudos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Estudo>> Detalhar([FromServices] DataContext context, int id)
        {
            var estudo = await context.Estudos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return estudo;
        }

        [HttpPost]
        [Route("criar")]
        public async Task<ActionResult<Estudo>> Criar(
            [FromServices] DataContext context,
            [FromBody]Estudo estudo)
        {
            if (ModelState.IsValid) {
                context.Estudos.Add(estudo);
                await context.SaveChangesAsync();
                return estudo;
            }
            else {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<Estudo>> Editar(
            [FromServices] DataContext context,
            [FromBody]Estudo estudo)
        {
             if (ModelState.IsValid) {
                context.Estudos.Update(estudo);
                await context.SaveChangesAsync();
                return estudo;
            }
            else {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Estudo>> Apagar(
            [FromServices] DataContext context, int id)
        {
             if (ModelState.IsValid) {
                Estudo estudo = await context.Estudos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                context.Estudos.Remove(estudo);
                await context.SaveChangesAsync();
                return estudo;
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}