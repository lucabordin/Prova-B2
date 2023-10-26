namespace WebAPIAutenticazioneUtenti.Helpers
{
    public interface IHelper
    {
        Task<string> GeneraToken();
    }
}
