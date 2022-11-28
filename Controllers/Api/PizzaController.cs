using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IDbPizzaRepository _pizzaRepository;
        
        public PizzaController (IDbPizzaRepository pizzaRepository)
        {
            _pizzaRepository= pizzaRepository;
        }

        public IActionResult Test()
        {

            return Ok("test");

        }

        public IActionResult Get()
        {
            List<Pizza> pizzas = _pizzaRepository.All();
            return Ok(pizzas);

        }

    }
}
