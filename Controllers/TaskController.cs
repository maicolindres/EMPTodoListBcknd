using EMPTodoListBcknd.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EMPTodoListBcknd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;
        
        private readonly DBContext _context;
        public TaskController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public ActionResult<IEnumerable<EMPTodoListBcknd.Models.Task>> GetTask()
        {
            return _context.Task.ToList();
        }

        // GET: api/Task/List
        [HttpGet("List/{id}")]
        public ActionResult<IEnumerable<EMPTodoListBcknd.Models.Task>> GetTaskList(int id)
        {
            return _context.Task.Where(task => task.ListId == id).ToList();
        }
      
        // GET: api/Task/1
        [HttpGet("{id}")]
        public ActionResult<EMPTodoListBcknd.Models.Task> GetTask(int id)
        {
            try
            {
                var task = _context.Task.Find(id);

                if (task == null)
                {
                    return NotFound();
                }
                return task;
            }
            catch (System.Exception)
            {
                
                throw new Exception("Algo paso mal...");
            }
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<EMPTodoListBcknd.Models.Task> CreateTask(EMPTodoListBcknd.Models.Task task)
        {                
            if (task == null)
            {
                return BadRequest();
            }
            try
            {             
                _context.Task.Add(task);
                _context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
                
            }
            return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
        }
        // PUT: api/Task
        [HttpPut("{id}")]
        public ActionResult<EMPTodoListBcknd.Models.Task> UpdateTask(EMPTodoListBcknd.Models.Task task, int id)
        {
            if (task == null)
            {
                return BadRequest();
            }
            
            if (task.TaskId != id)
                return BadRequest("ID Error not match with current Task");

            try
            {
                _context.Task.Update(task);
                _context.Entry(task).Property(x=> x.ListId).IsModified = false;
                _context.Entry(task).Property(x=> x.DateRegistered).IsModified = false;
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
            return NoContent();
        }

        // DELETE: api/Task
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            try
            {
                var task = _context.Task.Find(id);
                if (task == null)
                {
                    return NotFound();
                }
    
                _context.Task.Remove(task);
                _context.SaveChanges();
                return NoContent();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }
  
    }
}