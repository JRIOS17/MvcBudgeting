using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBudgeting.Models;

public class Expense
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime ExpenseDate { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    [StringLength(50)]
    public string? Category {  get; set; }
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [StringLength(120)]
    public string? Descrption { get; set; }
    [Required]
    [StringLength(100)]
    public string? BankAccount { get; set; }
}
