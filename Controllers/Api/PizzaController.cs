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

        //Metodo di prova che scrive in pagina un numero random
        public IActionResult Test()
        {
            Random random= new Random();

            return Ok(random.Next(0,100));

        }

        //Metodo che ritorna tutte le info sulle pizze
        public IActionResult Get()
        {
            List<Pizza> pizzas = _pizzaRepository.All();
            return Ok(pizzas);

        }

    }
}
