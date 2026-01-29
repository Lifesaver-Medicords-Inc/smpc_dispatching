using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IDepartmentApiService<T>
    {
        Task<HttpResponseModel<T>> CreateAsync(T entity);
        Task<HttpResponseModel<IEnumerable<T>>> GetAllAsync( Dictionary<string, string> query);
        Task<HttpResponseModel<T>> GetAsync(int Id);
        Task<HttpResponseModel<T>> UpdateAsync(T entity);
        Task<HttpResponseModel<T>> RemoveAsync(string deparment, int Id);
    }
}
