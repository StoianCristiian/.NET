using Microsoft.AspNetCore.Mvc;
using lab3.Data;
using lab3.Commands;
using lab3.Validators;

namespace lab3.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly InMemoryBookRepository _repo = new();

    [HttpGet]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var books = _repo.GetAll()
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _repo.GetById(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookCommand command)
    {
        var validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);
        if (!result.IsValid) return BadRequest(result.Errors);

        var book = new Book { Title = command.Title, Author = command.Author, Year = command.Year };
        _repo.Add(book);
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateBookCommand command)
    {
        var validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);
        if (!result.IsValid) return BadRequest(result.Errors);

        var existing = _repo.GetById(id);
        if (existing is null) return NotFound();

        existing.Title = command.Title;
        existing.Author = command.Author;
        existing.Year = command.Year;
        _repo.Update(existing);

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok();
    }
}