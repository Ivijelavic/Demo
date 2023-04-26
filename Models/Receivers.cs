using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Models
{
    public class Receivers
    {
        [Key]
        public int? Id_User { get; set; }
        [Required]
        public string? Ime { get; set; }
        [Required]
        public string? Prezime { get; set; }
        [Required]
        public string? PhoneNumber  { get; set; }
    }
}