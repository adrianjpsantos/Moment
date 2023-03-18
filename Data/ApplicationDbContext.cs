using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moment.Models.Entity;

namespace Moment.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Convention> Conventions { get; set; }
    public DbSet<ItemPurchase> ItemPurchases { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
}
