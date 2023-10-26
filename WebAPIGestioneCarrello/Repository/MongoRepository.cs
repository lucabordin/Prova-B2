using MongoDB.Driver;
using System.Xml.Linq;
using WebAPIAutenticazioneUtenti.Entities;
using WebAPIFaseA.DataSource;
using WebAPIFaseA.Entities;
using WebAPIMongoDB.DataAccess;
using WebAPIMongoDB.Entities;

namespace WebAPIMongoDB.Repository
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IContext _context;
        private readonly UtenteContext _context2;
        public MongoRepository(IContext context, UtenteContext context2)
            => (_context, _context2) = (context, context2);
        public async Task AggiungiCarrello(Carrello carrello)
        {
            await _context.OrdiniClienti.InsertOneAsync(carrello);
        }

        public async Task<List<Carrello>> RestituisciCarrello(int id)
        {
            FilterDefinition<Carrello> filter = Builders<Carrello>.Filter.Eq(p => p.IdCliente, id);
            return await _context.OrdiniClienti.Find(filter).ToListAsync();
        }

        public async Task<bool> VerificaToken(string token)
        {
            bool verifica;
            Utente utente = (Utente)_context2.Utenti.Where(u=>u.Token==token);
            DateTime datatoken = (DateTime)utente.DataToken;
            DateTime now = DateTime.Now;
            int scadenza = now.Minute - datatoken.Minute;
            if (scadenza > 5) verifica = false;
            else verifica = true;
            if (token == utente.Token) verifica = false;
            else verifica = true;
            return verifica;
        }
    }
}
