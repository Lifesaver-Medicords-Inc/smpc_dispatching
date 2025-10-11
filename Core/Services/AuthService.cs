
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace smpc_dispatching.Core.Services {
    public class AuthService : IAuthService {
        private readonly IHttpService _httpService;

        public AuthService(IHttpService httpService) {
            _httpService = httpService;
        }
        public async Task<HttpResponseModel<UserModel>> LoginAsync(Dictionary<string, dynamic> data) {
            var res = await _httpService.Post<HttpResponseModel<UserModel>>("login", data);
            return res;
        }
    }
}
