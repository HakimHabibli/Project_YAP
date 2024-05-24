﻿using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Models
{
    public class Muavin
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = default;
        public string ImagePath { get; set; }
    }
}
