using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public interface ITDocumentoRepositorio : IRepositorio<TDocumento>
    {
        Task<TDocumento> SelectByCod(string cod);
    }
}
