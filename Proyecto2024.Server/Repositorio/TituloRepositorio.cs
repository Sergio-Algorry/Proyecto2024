using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public class TituloRepositorio : Repositorio<Titulo>, ITituloRepositorio
    {
        private readonly Context context;

        public TituloRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Titulo?> SelectByCod(string cod)
        {
            Titulo? pepe = await context.Titulos
                             .FirstOrDefaultAsync(x => x.Codigo == cod);
            return pepe;
        }

    }
}
