using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
    public class CreateRayonHeyetVM
    {
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
