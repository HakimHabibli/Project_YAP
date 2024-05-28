using System.ComponentModel.DataAnnotations;
using Agsaqqallarsurasi.Models;
namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
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
