using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.Models
{
    public class CreateNewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public List<IFormFile> Photos { get; set; }

    }
}
