using Proyecto2024.BD.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public interface ITituloRepositorio : IRepositorio<Titulo>
    {
        Task<Titulo> SelectByCod(string cod);
    }
}
