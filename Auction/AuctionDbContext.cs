using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

    }
}