using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcBudgeting.Models.Context;

public partial class MvcbudgetingContext : DbContext
{
    public MvcbudgetingContext()
    {
    }

    public MvcbudgetingContext(DbContextOptions<MvcbudgetingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseSheet> ExpenseSheets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseSheet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExpenseS__3214EC07A02108C8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExpenseCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpenseItem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExpenseSubCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DD83FED7");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
