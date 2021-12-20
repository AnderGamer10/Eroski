using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Eroski.Models
{
    public class EroskiContext : DbContext
    {
        public EroskiContext(DbContextOptions<EroskiContext> options)
           : base(options)
        {
        }

        public DbSet<EroskiItems> EroskiItems { get; set; }
    }
}
