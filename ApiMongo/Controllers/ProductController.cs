using Microsoft.AspNetCore.Mvc;
using ApiMongo.Models;
using ApiMongo.Services;

namespace ApiMongo.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ServiceProduct _serviceProduct;
        public ProductController(ServiceProduct serviceProduct) =>
            _serviceProduct = serviceProduct;

        [HttpGet]
        public async Task<List<Student>> Get() =>
            await _serviceProduct.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Student newStudent)
        {
            await _serviceProduct.CreateAsync(newStudent);
            return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
        }

    }
}
