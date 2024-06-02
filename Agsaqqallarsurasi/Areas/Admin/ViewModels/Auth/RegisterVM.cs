using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels.Auth
{
    public class RegisterVM
    {
        [Required,MaxLength(100)]
        public string Fullname { get; set; }
        [Required, MaxLength(100)]

        public string Username { get; set; }
        [Required, MaxLength(255),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(10),DataType(DataType.Password)]

        public string Password { get; set; }
        [Required, MinLength(10), DataType(DataType.Password),Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }
    }
}
