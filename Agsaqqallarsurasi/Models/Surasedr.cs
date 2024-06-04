using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class Surasedr
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
