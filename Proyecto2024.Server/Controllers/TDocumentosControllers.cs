using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]
    public class TDocumentosControllers : ControllerBase
    {
        private readonly Context context;

        public TDocumentosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await context.TDocumentos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad)
        {
            try
            {
                context.TDocumentos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Put(int id, [FromBody] TDocumento entidad)
        {
            if (id != entidad.Id) 
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.TDocumentos
                             .Where(e => e.Id==id)
                             .FirstOrDefaultAsync();

            if (pepe == null)
            {
                return NotFound("No existe el tipo de documento buscado.");
            }

            pepe.Codigo = entidad.Codigo;
            pepe.Nombre = entidad.Nombre;
            pepe.Activo = entidad.Activo;

            try
            {
                context.TDocumentos.Update(pepe);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
