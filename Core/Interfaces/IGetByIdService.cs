using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IGetByIdService<T>
    {
        Task<HttpResponseModel<List<T>>> GetAsync(int id);
    }
}
