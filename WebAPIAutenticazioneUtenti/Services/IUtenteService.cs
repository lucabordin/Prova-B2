using WebAPIAutenticazioneUtenti.DTO;

namespace WebAPIAutenticazioneUtenti.Services
{
    public interface IUtenteService
    {
        Task<string> InserisciUtente(int id, UtenteDto utenteDto);
    }
}
