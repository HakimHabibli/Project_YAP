using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class Aparat
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public string FullName { get; set; }
  
        public DateTime DateTime { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
