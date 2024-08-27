using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBudgeting.Models;

namespace MvcBudgeting.Data
{
    public class MvcBudgetingContext : DbContext
    {
        public MvcBudgetingContext (DbContextOptions<MvcBudgetingContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBudgeting.Models.Expense> Expense { get; set; } = default!;
    }
}
