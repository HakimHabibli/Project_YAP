using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class RayonSedr
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
