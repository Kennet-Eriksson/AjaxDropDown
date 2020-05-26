using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EgetTest04.Models;

namespace EgetTest04.Data
{
    public class EgetTest04Context : DbContext
    {
        public EgetTest04Context (DbContextOptions<EgetTest04Context> options)
            : base(options)
        {
        }

        public DbSet<EgetTest04.Models.Country> Country { get; set; }

        public DbSet<EgetTest04.Models.City> City { get; set; }
    }
}
