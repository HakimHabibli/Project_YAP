using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
    public class UpdateAparatVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public string FullName { get; set; }

        public DateTime DateTime { get; set; }

        public IFormFile Photo { get; set; }
    }
}
