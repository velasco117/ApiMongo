using Microsoft.AspNetCore.Mvc;
using ApiMongo.Models;
using ApiMongo.Services;
using System.Text.RegularExpressions;

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
            string patttern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(patttern);

            bool isValid = regex.IsMatch(newUser.Email);
            Console.WriteLine(isValid ? "email is valid" : "email is invalid");
            if (!isValid)
            {
                return Ok(new { message = "email is invalid" });
            }
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
