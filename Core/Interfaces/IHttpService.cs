
using System.Net.Http;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces {
    public interface IHttpService {
        Task<T> Get<T>(string url);

        Task<T> Post<T>(string url, object payload);

        Task<T> Put<T>(string url, object payload);

        Task<T> Delete<T>(string url, object payload = null);

        Task<T> PostMultipartAsync<T>(string url, HttpContent content);
    }
}
