using Microsoft.EntityFrameworkCore;
using moment3_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Data
{
    public class CDContext : DbContext
    {
        public CDContext(DbContextOptions<CDContext> options) : base(options)
        {

        }

        //Referenser till de models som används
        public DbSet<CD> CD { get; set; }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<User> User { get; set; }
    }
}
