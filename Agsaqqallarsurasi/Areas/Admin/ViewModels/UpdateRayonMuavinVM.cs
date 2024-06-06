using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
	public class UpdateRayonMuavinVM
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		public DateTime DateTime { get; set; }

		public IFormFile Photo { get; set; }
	}
}
