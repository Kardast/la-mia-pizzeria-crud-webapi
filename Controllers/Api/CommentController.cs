using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private PizzeriaDbContext db;

        public CommentController(PizzeriaDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        // public void Post(Message message) equivalente anche senza [FormBody]
        public IActionResult Create([FromBody] Comment comment)
        {

            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(comment);
        }
    }
}
