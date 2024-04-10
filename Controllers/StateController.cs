using EMPTodoListBcknd.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPTodoListBcknd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;
        private readonly DBContext _context;
        public StateController(DBContext context)
        {
            _context = context;
        }

        // GET: api/State
        [HttpGet]
        public ActionResult<IEnumerable<State>> GetState()
        {try
        {
            
                return _context.State.ToList();
        }
        catch (System.Exception)
        {
                throw new Exception("Algo paso mal...");
        }
        }
        
    }
}