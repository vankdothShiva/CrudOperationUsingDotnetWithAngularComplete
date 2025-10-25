using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly DbContext_Login _DbContext_Login;
       
        public SignUpController(DbContext_Login DbContext_Login)
        {
            this._DbContext_Login = DbContext_Login;
        }
        [HttpGet]
        public async Task<ActionResult<SignUp>> GetAllValues()
        {
            return Ok( await _DbContext_Login.SignUp.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostDataForSignUp([FromBody]SignUp signUp)
        {
            if(signUp==null || string.IsNullOrEmpty(signUp.ToString()))
            {
                BadRequest("Invalid Data");
            }
            var Data=  _DbContext_Login.SignUp.Add(signUp);
            await _DbContext_Login.SaveChangesAsync();
            return Ok(new { message = "Inserted the Data" });
        }
    }
}
