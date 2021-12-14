using AngleSharp.Dom;
using Arch.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestePagCerto.Models;



namespace TestePagCerto.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        //explicita na hora da executação, queremos fazer modificação
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //explicita na hora da executação, queremos fazer modificação


            builder.Entity<Payment>()
.HasKey(p => p.Id);

            builder.Entity<Payment>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.PaitAt).HasColumnName("DataPagamento").IsRequired();
            builder.Entity<Payment>().Property(p => p.CanceledAt).HasColumnName("DataCancelamento");
            builder.Entity<Payment>().Property(p => p.Amount).HasColumnName("Total").HasColumnType("decimal(8,2)");


            builder.Entity.HasOne(p => p.BankSlip)
            .WithOne(p => p.Payment)
            .HasForeignKey<Payment>(p => p.BankSlip)
            .OnDelete(Arch.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.Entity.HasOne(p => p.CardTransaction)
           .WithOne(p => p.Payment)
           .HasForeignKey<Payment>(p => p.CardTransaction)
           .OnDelete(Arch.EntityFrameworkCore.DeleteBehavior.Restrict);


        }
        public Arch.EntityFrameworkCore.DbSet<Payment> payments { get; set; }
    }
}
