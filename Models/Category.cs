using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker_System.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        // Default type is expense
        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";
    }
}
