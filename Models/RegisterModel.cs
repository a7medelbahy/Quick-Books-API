using System.ComponentModel.DataAnnotations;

namespace Quick_Books.Models
{
    public class RegisterModel
    {
        [Required, Length(3,50)]
        public string FirstName { get; set; }
        [Required, Length(3,50)]
        public string LastName { get; set; }
        [Required, Length(3,50)]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }

    }
}
