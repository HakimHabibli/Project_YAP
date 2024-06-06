namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
	public class UpdateCongratsVM
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public int Age { get; set; }
		public string Description { get; set; }
		public IFormFile Photo { get; set; }
		public DateTime DateTime { get; set; }
	}
}
