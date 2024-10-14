using Microsoft.AspNetCore.Mvc;
using Proyecto2024.BD.Data.Entity;
using Proyecto2024.Server.Repositorio;
using Proyecto2024.Shared.DTO;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/nuevo")]
    public class NuevoControllers : ControllerBase
    {
        private readonly ITituloRepositorio repositorioTitulo;
        private readonly ITDocumentoRepositorio repositorioTdoc;

        public NuevoControllers(ITituloRepositorio repositorioTitulo,
                                ITDocumentoRepositorio repositorioTdoc)
        {
            this.repositorioTitulo = repositorioTitulo;
            this.repositorioTdoc = repositorioTdoc;
        }

        [HttpGet("GetTitulos")]    
        public async Task<ActionResult<List<Titulo>>> GetTitulo()
        {
            return await repositorioTitulo.Select();
        }


        [HttpGet("GetTDocumento")]    
        public async Task<ActionResult<List<TDocumento>>> GetTDocumento()
        {
            return await repositorioTdoc.Select();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTDoc_TituloDTO entidadDTO)
        {
            try
            {
                var pepe1 = await repositorioTdoc.SelectByCod(entidadDTO.CodigoTdoc);
                if (pepe1 != null) 
                {
                    return BadRequest($"El código del tipo de documento {entidadDTO.CodigoTdoc} ya existe.");
                }
                var pepe2 = await repositorioTitulo.SelectByCod(entidadDTO.CodigoTitulo);
                if (pepe2 != null)
                {
                    return BadRequest($"El código del título {entidadDTO.CodigoTitulo} ya existe.");
                }

                //TDocumento entTDoc = new TDocumento();
                //entTDoc.Codigo = entidadDTO.CodigoTitulo;

                TDocumento entTDoc = new TDocumento
                {
                    Codigo = entidadDTO.CodigoTdoc,
                    Nombre = entidadDTO.NombreTdoc
                };

                int i = await repositorioTdoc.Insert(entTDoc);
                if (i == 0)
                {
                    BadRequest("No se pudo cargar el tipo de documento");
                }

                Titulo enttitulo = new Titulo
                {
                    Codigo = entidadDTO.CodigoTitulo,
                    Nombre = entidadDTO.NombreTitulo
                };
                i = await repositorioTitulo.Insert(enttitulo);
                if (i == 0)
                {
                    BadRequest("No se pudo cargar el tipo de documento");
                }
                return i;
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
