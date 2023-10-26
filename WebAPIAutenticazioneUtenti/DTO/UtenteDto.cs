using System.ComponentModel.DataAnnotations;

namespace WebAPIAutenticazioneUtenti.DTO
{
    public class UtenteDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passward { get; set; }
    }
}
