using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
            => _context.Books.ToList();

        public Book? GetById(int id) => _context.Books.Find(id);

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetByAuthor(string author)
            => _context.Books.Where(b => b.Author.Contains(author)).ToList();
    }
} 