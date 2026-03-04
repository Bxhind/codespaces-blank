using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class ReaderService
    {
        private readonly LibraryContext _context;

        public ReaderService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Reader> GetAll()
            => _context.Readers.ToList();

        public Reader? GetById(int id) => _context.Readers.Find(id);

        public void Add(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var reader = _context.Readers.Find(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Loan> GetHistory(int readerId)
            => _context.Loans
                .Include(l => l.Book)
                .Where(l => l.ReaderId == readerId)
                .ToList();
    }
}