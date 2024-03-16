using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herfitk.Core.Models.Data;

namespace Herfitk.Repository.DbContextWithIDentity
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<HerfitkContext>
    {
        public HerfitkContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HerfitkContext>();
            optionsBuilder.UseSqlServer("Server = .; Database = Herifa_Web; Trusted_Connection = True;encrypt=false");

            return new HerfitkContext(optionsBuilder.Options);
        }
    }
}
