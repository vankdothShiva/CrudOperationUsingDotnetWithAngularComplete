using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Model
{
    [Table("UserSignUps")]  //tell the tablename 
    public class SignUp
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? password { get; set; }
        public Login? Login { get; set; }
    }
}
