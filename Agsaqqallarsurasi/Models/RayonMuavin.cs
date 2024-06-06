using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class RayonMuavin
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    
        public bool IsDeleted { get; set; }
        public string ImagePath { get; set; }
    }
}
