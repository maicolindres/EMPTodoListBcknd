using EMPTodoListBcknd.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPTodoListBcknd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;
        private readonly DBContext _context;
        public ListController(DBContext context)
        {
            _context = context;
        }

        // GET: api/List
        [HttpGet]
        public ActionResult<IEnumerable<List>> GetList()
        {
            try
            {
                
                    return _context.List.ToList();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }

        // POST: api/List
        [HttpPost]
        public ActionResult<List> CreateList(List list)
        {                
            if (list == null)
            {
                return BadRequest();
            }
            try
            {             
                _context.List.Add(list);
                _context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
                
            }
            return CreatedAtAction(nameof(GetList), new { id = list.ListId }, list);
        }
        
    }
}