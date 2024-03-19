using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Repository
{
    public class StaffRepository : GenericRepository<Staff> , IStaffRepository
    {
        private readonly HerfitkContext context;

        public StaffRepository(HerfitkContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<Staff>> GetAllStaffIncluding()
        {

            var getData = await context.Staff
                                .Include(x => x.StaffUser)
                                .ToListAsync();
            return getData;
        }
    }
}
