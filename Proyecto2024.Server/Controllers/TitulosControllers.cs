using Microsoft.AspNetCore.Mvc;
using Proyecto2024.BD.Data.Entity;
using Proyecto2024.BD.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/Titulos")]
    public class TitulosControllers : ControllerBase
    {
        private readonly Context context;

        public TitulosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]    //api/Titulos
        public async Task<ActionResult<List<Titulo>>> Get()
        {
            return await context.Titulos.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Titulos/2
        public async Task<ActionResult<Titulo>> Get(int id)
        {
            Titulo? pepe = await context.Titulos.FirstOrDefaultAsync(x => x.Id == id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("GetByCod/{cod}")] //api/Titulos/GetByCod/DNI
        public async Task<ActionResult<Titulo>> GetByCod(string cod)
        {
            Titulo? pepe = await context.Titulos
                             .FirstOrDefaultAsync(x => x.Codigo == cod);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("existe/{id:int}")] //api/Titulos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Titulos.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Titulo entidad)
        {
            try
            {
                context.Titulos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Titulos/2
        public async Task<ActionResult> Put(int id, [FromBody] Titulo entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.Titulos
                             .Where(reg => reg.Id == id)
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
                context.Titulos.Update(pepe);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Titulos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Titulos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            Titulo EntidadABorrar = new Titulo();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    
    }
}
