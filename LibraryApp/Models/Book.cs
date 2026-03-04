using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Author { get; set; } = string.Empty;

        [Range(1500, 2100)]
        public int Year { get; set; }

        [Range(0, 1000)]
        public int Quantity { get; set; }

        public bool Available => Quantity > 0;

        public List<Loan>? Loans { get; set; }
    }
} 