using System;
using System.Collections.Generic;

namespace MvcBudgeting.Models;

public partial class ExpenseSheet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly ExpenseDate { get; set; }

    public string ExpenseCategory { get; set; } = null!;

    public string? ExpenseSubCategory { get; set; }

    public decimal ExpenseAmount { get; set; }

    public string ExpenseItem { get; set; } = null!;
}
