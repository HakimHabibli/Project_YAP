using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
	public class CreateRayonMuavinVM
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }

		public IFormFile Photo { get; set; }
		public DateTime DateTime { get; set; }
	}
}
