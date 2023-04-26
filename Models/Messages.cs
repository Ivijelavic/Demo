using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Models
{
    public class Messages
    {
        [Key]
        public int Id_Message { get; set; }

        public string? MessageText { get; set; }

        public bool? Send { get; set; }

        public DateTime? SendDT { get; set; }
    }
}
