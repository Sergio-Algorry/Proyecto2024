using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.BD.Data.Entity;
using Proyecto2024.Server.Repositorio;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]
    public class TDocumentosControllers : ControllerBase
    {
        private readonly ITDocumentoRepositorio repositorio;

        public TDocumentosControllers(ITDocumentoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/TDocumentos
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await repositorio.Select();
        }

        /// <summary>
        /// Endpoint para obtener un objeto de tipo de documento
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns></returns>
        [HttpGet("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            TDocumento? pepe = await repositorio.SelectById(id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("GetByCod/{cod}")] //api/TDocumentos/GetByCod/DNI
        public async Task<ActionResult<TDocumento>> GetByCod(string cod)
        {
            TDocumento? pepe = await repositorio.SelectByCod(cod);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("existe/{id:int}")] //api/TDocumentos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Put(int id, [FromBody] TDocumento entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var pepe = await repositorio.Update(id, entidad);

                if (!pepe)
                {
                    return BadRequest("No se pudo actualizar el tipo de documento");
                }
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
            var resp = await repositorio.Delete(id);
            if (!resp)
            { return BadRequest("El tipo de documento no se pudo borrar"); }
            return Ok();
        }

    }
}
