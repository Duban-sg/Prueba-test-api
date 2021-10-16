using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TestApiContext : DbContext
    {
        public TestApiContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AdminssionAplication> AdminssionAplication { get; set; }
    }
}
