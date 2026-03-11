using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IGeneralSetupService : IApiService<SetupModel>
    {
        Task<HttpResponseModel<IEnumerable<SetupModel>>> GetAllAsync(Dictionary<string, string> query, string endpoint);
    }
}
