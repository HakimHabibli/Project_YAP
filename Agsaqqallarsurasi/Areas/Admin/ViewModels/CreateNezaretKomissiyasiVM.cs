using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
    public class CreateNezaretKomissiyasiVM
    {
        [Required]
        [MaxLength(127)]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public IFormFile Photo { get; set; }

    }
}
