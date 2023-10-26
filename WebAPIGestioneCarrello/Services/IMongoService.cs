using WebAPIMongoDB.Entities;

namespace WebAPIMongoDB.Services
{
    public interface IMongoService
    {
        Task<List<Carrello>> GetCarrello(int id, string token);
        Task AddCarrello(Carrello carrello, string token);
    }
}
