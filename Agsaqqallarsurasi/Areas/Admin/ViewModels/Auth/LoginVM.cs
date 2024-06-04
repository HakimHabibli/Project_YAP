using System.ComponentModel.DataAnnotations;

namespace Agsaqqallarsurasi.Areas.Admin.ViewModels.Auth
{
    public class LoginVM
    {
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(10), DataType(DataType.Password)]

        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
