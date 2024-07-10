using Microsoft.AspNetCore.Mvc;
using ApiMongo.Models;
using ApiMongo.Services;

namespace ApiMongo.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginServicecs _loginServicecs;
        public LoginController(LoginServicecs loginServicecs)
        {
            _loginServicecs = loginServicecs;
        }

        [HttpGet]
        public async Task<List<Login>> Get() =>
            await _loginServicecs.GetAsync();
        [HttpPost]
        public async Task<IActionResult> Post(Login newUser)
        {
            await _loginServicecs.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }
        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Login>> Get(string id) {
            var user = await _loginServicecs.GetAsync(id);
            if(user is null){
                return NotFound();
            }
            return user;
        }
        [HttpPost("signin")]
        public async Task<ActionResult<Login>> Signin([FromBody] Login login) {
            Console.WriteLine(login.Email);
            var user = await _loginServicecs.GetAsync(login.Email);
            if(user is null){
                return NotFound();
            }
            return user;        
        }

    }
}
