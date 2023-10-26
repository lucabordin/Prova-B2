using Microsoft.EntityFrameworkCore;
using WebAPIAutenticazioneUtenti.Entities;

namespace WebAPIFaseA.DataSource
{
    public class UtenteContext: DbContext
    {
        public UtenteContext()
        {

        }
        public UtenteContext(DbContextOptions<UtenteContext> options)
        : base(options)
        {

        }
        public DbSet<Utente> Utenti { get; set; }
    }
}
