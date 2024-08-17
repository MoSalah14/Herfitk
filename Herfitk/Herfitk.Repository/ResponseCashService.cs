using Azure;
using Herfitk.Core.Service_Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Herfitk.Repository
{
    public class ResponseCashService : IResponseCashService
    {
        private readonly IDatabase dataBase;

        public ResponseCashService(IConnectionMultiplexer _redis)
        {
            dataBase = _redis.GetDatabase();
        }
        public async Task SetCashResponseAsync(string CashKey, object Response, TimeSpan LiveTime)
        {
            if (Response is null) return;
            // Convert Json To CamelCase to support json when send it to front end
            var SerializeOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            //Convert data to Json
            var serializedResponse = JsonSerializer.Serialize(Response, SerializeOptions);

            await dataBase.StringSetAsync(CashKey, serializedResponse, LiveTime);
        }

        public async Task<string?> GetCashedResponseAsync(string CashKey)
        {
            var CashResponse = await dataBase.StringGetAsync(CashKey);
            if (CashResponse.IsNullOrEmpty) return null;

            return CashResponse;
        }
    }
}
