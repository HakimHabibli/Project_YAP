using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
    public class CreateHeyetVM
    {
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
