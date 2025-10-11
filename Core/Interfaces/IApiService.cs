

using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces {
   public interface IApiService<T> {

       Task<HttpResponseModel<T>> CreateAsync(T entity);
       Task<HttpResponseModel<IEnumerable<T>>> GetAllAsync(Dictionary<string,string> query);
       Task<HttpResponseModel<T>> GetAsync(int Id);
       Task<HttpResponseModel<T>> UpdateAsync(T entity);
        Task<HttpResponseModel<T>> RemoveAsync(int Id);
    }
}
