using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class RayonHeyet
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
