using Microsoft.EntityFrameworkCore;

namespace MobileRecharge.Models
{
    public class MobileRechargeDbContext : DbContext
    {
        public MobileRechargeDbContext() { }
        public MobileRechargeDbContext(DbContextOptions<MobileRechargeDbContext> options) : base(options) { }
        public DbSet<CustomerDetails> Customers { get; set; }
        public DbSet<RechargeHistory> History {  get; set; } 
    }
}
