using Microsoft.AspNetCore.Mvc;
using Proyecto2024.BD.Data.Entity;
using Proyecto2024.BD.Data;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.Shared.DTO;
using AutoMapper;
using Proyecto2024.Server.Repositorio;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/Titulos")]
    public class TitulosControllers : ControllerBase
    {
        private readonly ITituloRepositorio repositorio;
        private readonly IMapper mapper;

        public TitulosControllers(ITituloRepositorio repositorio,
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/Titulos
        public async Task<ActionResult<List<Titulo>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Titulos/2
        public async Task<ActionResult<Titulo>> Get(int id)
        {

            Titulo? pepe = await repositorio.SelectById(id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("GetByCod/{cod}")] //api/Titulos/GetByCod/DNI
        public async Task<ActionResult<Titulo>> GetByCod(string cod)
        {
            Titulo? pepe = await repositorio.SelectByCod(cod);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("existe/{id:int}")] //api/Titulos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTituloDTO entidadDTO)
        {
            try
            {
                Titulo entidad = mapper.Map<Titulo>(entidadDTO);

                return await repositorio.Insert(entidad);
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
            var pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound("No existe el tipo de documento buscado.");
            }

            pepe.Codigo = entidad.Codigo;
            pepe.Nombre = entidad.Nombre;
            pepe.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, pepe);
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
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest(); 
            }
        }

    }
}
