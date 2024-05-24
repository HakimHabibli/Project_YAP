using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class NezaretKomissiyasi
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(127)]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string ImagePath { get; set; }

    }
}
