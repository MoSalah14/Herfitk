using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Service_Contract
{
    public interface IResponseCashService
    {
        Task SetCashResponseAsync(string CashKey, object Response, TimeSpan LiveTime);

        Task<string?> GetCashedResponseAsync(string CashKey);
    }
}
