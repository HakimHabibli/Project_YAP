using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.ViewModels
{
    public class CreatePostVm
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<IFormFile> Photos { get; set; }
        
    }
}
