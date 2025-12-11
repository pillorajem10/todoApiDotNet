using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoApiDotNet.Data;
using todoApiDotNet.Models;

namespace todoApiDotNet.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    // List all todos GET: /api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
    {
        var todos = await _context.Todos.ToListAsync();
        return Ok(todos);
    }

    // Create a new todo POST: /api/todo
    [HttpPost]
    public async Task<ActionResult<Todo>> Create([FromBody] Todo todo)
    {
        var newTodo = new Todo
        {
            title = todo.title,
            isComplete = false
        };

        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByID), new { id = newTodo.Id }, newTodo);
    }

    // Get a todo by ID GET: /api/todo/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetByID(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }
}