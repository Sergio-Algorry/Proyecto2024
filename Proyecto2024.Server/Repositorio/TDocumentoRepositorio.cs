using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    /// <summary>
    /// 
    /// </summary>
    public class TDocumentoRepositorio : Repositorio<TDocumento>, ITDocumentoRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Context context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TDocumentoRepositorio(Context context) : base(context) 
        {
            this.context = context;
        }

        /// <summary>
        /// devuelve un objeto de la entity TDocumento
        /// </summary>
        /// <param name="cod">codigo del tipo de documento</param>
        /// <returns></returns>
        public async Task<TDocumento> SelectByCod(string cod)
        {
            TDocumento? pepe = await context.TDocumentos
                                     .FirstOrDefaultAsync(x => x.Codigo == cod);
            return pepe;
        }

    }
}
