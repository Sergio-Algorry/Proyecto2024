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

        [HttpGet]    //api/TDocumentos
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await context.TDocumentos.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            TDocumento? pepe = await context.TDocumentos
                             .FirstOrDefaultAsync(x => x.Id == id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("GetByCod/{cod}")] //api/TDocumentos/GetByCod/DNI
        public async Task<ActionResult<TDocumento>> GetByCod(string cod)
        {
            TDocumento? pepe = await context.TDocumentos
                             .FirstOrDefaultAsync(x => x.Codigo == cod);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("existe/{id:int}")] //api/TDocumentos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.TDocumentos.AnyAsync(x => x.Id == id);
            return existe;
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
            catch (Exception err)
            {
                return BadRequest(err.Message);
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
                             .Where(reg => reg.Id==id)
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

        [HttpDelete("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.TDocumentos.AnyAsync(x => x.Id==id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            TDocumento EntidadABorrar = new TDocumento();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
