using WebAPIMongoDB.Entities;
using WebAPIMongoDB.Repository;

namespace WebAPIMongoDB.Services
{
    public class MongoService : IMongoService
    {
        IMongoRepository _repository;
        public MongoService(IMongoRepository repository)
        => _repository = repository;
        public async Task AddCarrello(Carrello carrello, string token)
        {
            bool verifica = await _repository.VerificaToken(token);
            if (verifica) await _repository.AggiungiCarrello(carrello);
        }

        public async Task<List<Carrello>> GetCarrello(int id, string token)
        {
            bool verifica = await _repository.VerificaToken(token);
            if (verifica) return await _repository.RestituisciCarrello(id);
            else return null;
        }
    }
}
