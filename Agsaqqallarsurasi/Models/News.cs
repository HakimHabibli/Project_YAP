using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
	public class News
	{
		public News() 
		{
			NewsImages = new List<NewsImage>();
		}
		public int Id { get; set; }
		[Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime DateTime { get; set; }
        [Required]
        public virtual List<NewsImage> NewsImages { get; set; }
    }
}
