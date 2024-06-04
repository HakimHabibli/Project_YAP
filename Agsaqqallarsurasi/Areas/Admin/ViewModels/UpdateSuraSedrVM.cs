using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
	public class UpdateSuraSedrVM
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string FullName { get; set; }
		[Required]
		public string Description { get; set; }
		public IFormFile Photo { get; set; }
	}
}
