using System.ComponentModel.DataAnnotations;

namespace KidKinder.ViewModels.Auths
{
    public class RegisterVM
    {
        [Required, MaxLength(32)]
        public string Fullname { get; set; } = null!;
        [Required, MaxLength(64),EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MaxLength(32)]
        public string Username { get; set; } = null!;
        [Required, MaxLength(32),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(32), DataType(DataType.Password),Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
