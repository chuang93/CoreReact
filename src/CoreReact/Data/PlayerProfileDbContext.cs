using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreReact.Models;

namespace CoreReact.Data
{
    public class PlayerProfileDbContext : DbContext
    {
        public PlayerProfileDbContext (DbContextOptions<PlayerProfileDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlayerProfile> PlayerProfile { get; set; }
    }
}
