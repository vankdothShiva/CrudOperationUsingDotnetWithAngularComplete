using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Model
{
    [Table("Logins")]
    public class Login
    {
        [Key]
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? Role { get; set; }
        public string? token { get; set; }
        public bool rememberMe { get; set; }
        public int UserSignUpId { get; set; }

        [ForeignKey("UserSignUpId")]
        public SignUp? UserSignUp { get; set; }
    }
}
