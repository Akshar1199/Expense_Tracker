using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Expense_Tracker_System.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        // CategoryId - Foreign Key
        public int CategoryId { get; set; }

        // Navigational Property 
        public Category? Category { get; set; }

        public int Amount { get; set; }

        // Here Description is not mandatory, so type is defines as nullable
        [Column(TypeName = "nvarchar(60)")]
        public string? Description { get; set; }

        // Default value is current date
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
