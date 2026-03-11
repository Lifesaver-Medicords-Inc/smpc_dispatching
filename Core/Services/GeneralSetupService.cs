using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    class GeneralSetupService : BaseApiService<SetupModel>
    {
        public GeneralSetupService(IHttpService httpService) : base(httpService, "general-setup") { }
    }
}
