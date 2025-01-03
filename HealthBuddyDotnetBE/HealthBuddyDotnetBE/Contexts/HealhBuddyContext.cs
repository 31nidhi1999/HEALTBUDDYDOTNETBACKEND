using Microsoft.EntityFrameworkCore;

namespace HealthBuddyDotnetBE.Contexts
{
    public class HealhBuddyContext : DbContext
    {
       
        public HealhBuddyContext(DbContextOptions<HealhBuddyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              
        }
    }
}
