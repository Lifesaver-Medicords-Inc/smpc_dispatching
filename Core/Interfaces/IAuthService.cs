using System.Collections.Generic;
using System.Threading.Tasks;
using smpc_dispatching.Core.Models;

namespace smpc_dispatching.Core.Interfaces {
    public interface IAuthService {
        Task<HttpResponseModel<UserModel>> LoginAsync(Dictionary<string, dynamic> data);
    }
}
