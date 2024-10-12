using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.CustomHttpClient
{
    public interface IHttpClientHelper
    {
        void GenerateClient(string clientCode);
        Task<T> Post<T, K>(string endpoint, K item, CancellationToken token);
        Task<T> Put<T, K>(string endpoint, K item, CancellationToken token);
        Task<T> Delete<T, K>(string endpoint, K item, CancellationToken token);
        Task<T> Get<T, K>(string endpoint, K item, CancellationToken token);
    }
}
