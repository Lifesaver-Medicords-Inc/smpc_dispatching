using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    class SalesOrderWithApprovedIRDetailsService : ISalesOrderWithApprovedIRDetailsService
    {
        private readonly IHttpService _httpService;

        public SalesOrderWithApprovedIRDetailsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<List<SalesOrderWithApprovedIRDetailsModel>>> GetAsync(int id)
        {
            var res = await _httpService.Get<HttpResponseModel<List<SalesOrderWithApprovedIRDetailsModel>>>($"{Endpoint.IRD_APPROVED}{id}");
            return res;
        }
    }
}
