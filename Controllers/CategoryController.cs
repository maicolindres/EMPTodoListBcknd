using EMPTodoListBcknd.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPTodoListBcknd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;
        private readonly DBContext _context;
        public CategoryController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            try
            {
                return _context.Category.ToList();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }
        
    }
}