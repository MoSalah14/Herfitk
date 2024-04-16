using Herfitk.Core.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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