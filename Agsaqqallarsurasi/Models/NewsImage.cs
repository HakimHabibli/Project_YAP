namespace Agsaqqallarsurasi.Models
{
    public class NewsImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
