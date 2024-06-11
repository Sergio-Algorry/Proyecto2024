using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public class TDocumentoRepositorio : Repositorio<TDocumento>, ITDocumentoRepositorio
    {
        private readonly Context context;

        public TDocumentoRepositorio(Context context) : base(context) 
        {
            this.context = context;
        }

        public async Task<TDocumento> SelectByCod(string cod)
        {
            TDocumento? pepe = await context.TDocumentos
                                     .FirstOrDefaultAsync(x => x.Codigo == cod);
            return pepe;
        }

    }
}
