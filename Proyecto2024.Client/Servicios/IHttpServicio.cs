
namespace Proyecto2024.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}