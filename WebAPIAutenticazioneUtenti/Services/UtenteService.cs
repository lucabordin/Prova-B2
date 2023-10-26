using Microsoft.EntityFrameworkCore;
using WebAPIAutenticazioneUtenti.DTO;
using WebAPIAutenticazioneUtenti.Entities;
using WebAPIAutenticazioneUtenti.Helpers;
using WebAPIFaseA.DataSource;

namespace WebAPIAutenticazioneUtenti.Services
{
    public class UtenteService : IUtenteService
    {
        UtenteContext _context;
        private IHelper _helper;
        public UtenteService(UtenteContext context, IHelper helper)
        => (_context, _helper) = (context, helper);
        public async Task<string> InserisciUtente(int id, UtenteDto utenteDto)
        {
            string token = await _helper.GeneraToken();
            Utente utente = await _context.Utenti.FindAsync(id);
            utente.DataToken = DateTime.Now;
            utente.Token = token;
            _context.Entry(utente).State = EntityState.Modified;
            try
            {
                int numeroRecordsInseriti = await _context.SaveChangesAsync();
                if (numeroRecordsInseriti != 1)
                {
                    string messaggioErrore = "Operazione di inerimento non effettuata";
                    throw new Exception(messaggioErrore);
                }
                return token;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
