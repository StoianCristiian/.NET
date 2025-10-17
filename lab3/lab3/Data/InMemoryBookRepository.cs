using System.Collections.Generic;
using System.Linq;

namespace lab3.Data;

public class InMemoryBookRepository
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public IEnumerable<Book> GetAll() => _books;
    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index != -1) _books[index] = book;
    }

    public void Delete(int id) => _books.RemoveAll(b => b.Id == id);
}