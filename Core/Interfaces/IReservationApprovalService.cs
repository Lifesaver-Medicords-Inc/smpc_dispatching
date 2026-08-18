using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces {
    // Approve/Reject aren't CRUD in the BaseApiService<T> sense (no body, the decision
    // is keyed off the logged-in user's session/Position server-side), so this is its
    // own small interface rather than reusing IApiService<T>.
    public interface IReservationApprovalService {
        Task<HttpResponseModel<IEnumerable<PendingReservationModel>>> GetPendingAsync();

        Task<HttpResponseModel<object>> ApproveAsync(uint reservationId);

        Task<HttpResponseModel<object>> RejectAsync(uint reservationId);
    }
}
