using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class ReservationApprovalService : IReservationApprovalService {
        private readonly IHttpService _httpService;

        public ReservationApprovalService(IHttpService httpService) {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<IEnumerable<PendingReservationModel>>> GetPendingAsync()
            => await _httpService.Get<HttpResponseModel<IEnumerable<PendingReservationModel>>>(Endpoint.RESERVATION_PENDING);

        // No body needed - the server identifies who's approving off the session token
        // already attached to every request (see HttpService), then checks that user's
        // Position against the RESERVATION_APPROVAL access code itself. A 403 comes back
        // as Success = false with Message explaining why, same as any other API error.
        public async Task<HttpResponseModel<object>> ApproveAsync(uint reservationId)
            => await _httpService.Post<HttpResponseModel<object>>(string.Format(Endpoint.RESERVATION_APPROVE, reservationId), null);

        public async Task<HttpResponseModel<object>> RejectAsync(uint reservationId)
            => await _httpService.Post<HttpResponseModel<object>>(string.Format(Endpoint.RESERVATION_REJECT, reservationId), null);
    }
}
