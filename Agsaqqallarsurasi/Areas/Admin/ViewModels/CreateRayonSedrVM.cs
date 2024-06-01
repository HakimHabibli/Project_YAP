﻿using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels
{
    public class CreateRayonSedrVM
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
