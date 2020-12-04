using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class RefreshTokenContext : DbContext
    {
        public RefreshTokenContext(DbContextOptions<RefreshTokenContext> dbContextOptions)
            :base(dbContextOptions)
        { 
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
