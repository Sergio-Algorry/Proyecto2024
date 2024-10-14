using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public interface ITDocumentoRepositorio : IRepositorio<TDocumento>
    {
        /// <summary>
        /// devuelve un objeto de la entity TDocumento
        /// </summary>
        /// <param name="cod">codigo del tipo de documento</param>
        /// <returns></returns>
        Task<TDocumento> SelectByCod(string cod);
    }
}
