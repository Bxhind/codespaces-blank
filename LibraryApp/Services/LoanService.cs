using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public class LoanService
    {
        private readonly LibraryContext _context;

        public LoanService(LibraryContext context)
        {
            _context = context;
        }

        public void Borrow(int bookId, int readerId)
        {
            var book = _context.Books.Find(bookId);

            if (book == null || book.Quantity <= 0)
                throw new Exception("Книга недоступна");

            book.Quantity--;

            var loan = new Loan
            {
                BookId = bookId,
                ReaderId = readerId,
                BorrowDate = DateTime.Now
            };

            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void Return(int loanId)
        {
            var loan = _context.Loans.Include(l => l.Book)
                                     .First(l => l.Id == loanId);

            loan.ReturnDate = DateTime.Now;
            loan.Book.Quantity++;

            _context.SaveChanges();
        }

        public IEnumerable<Loan> GetActive()
            => _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .Where(l => l.ReturnDate == null)
                .ToList();
    }
}