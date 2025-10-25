using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DTO;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbContext_Login _DbContext_Login;
        private readonly TokenService _tokenService;
        public LoginController(DbContext_Login DbContext_Login, TokenService tokenService)
        {
            _DbContext_Login = DbContext_Login;
            _tokenService = tokenService;
        }
        [HttpGet]
        public async Task<ActionResult<Login>> GetByLoginDetails()
        {

            var Data= await  _DbContext_Login.Logins.ToListAsync();
            if (Data == null)
            {
                return NotFound("No users found");
            }
            return Ok(Data);
                
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            var user = await _DbContext_Login.Logins
                .FirstOrDefaultAsync(x => x.username == loginDto.Username && x.password == loginDto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = _tokenService.CreateToken(user);
            user.token = token;
          
            await _DbContext_Login.SaveChangesAsync();

            return Ok(new
            {
                username = user.username,
                role = user.Role,
                token = token
            });
        }
    }
}
