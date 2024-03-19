using Herfitk.Core.Models.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Repository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        public Task<List<Staff>> GetAllStaffIncluding();
    }
}
