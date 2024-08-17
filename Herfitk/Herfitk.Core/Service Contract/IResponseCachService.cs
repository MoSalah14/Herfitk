using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Service_Contract
{
    public interface IResponseCachService
    {
        Task SetCachResponseAsync(string CachKey, object Response, TimeSpan LiveTime);

        Task<string?> GetCachedResponseAsync(string CachKey);
    }
}
