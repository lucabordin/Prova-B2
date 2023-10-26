using System.ComponentModel.DataAnnotations;

namespace WebAPIAutenticazioneUtenti.Entities
{
    public class Utente
    {
        [Key]
        public int IdUtente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public DateTime DataDiNascita { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? DataToken { get; set; }
        public string? Token { get; set; }
    }
}
