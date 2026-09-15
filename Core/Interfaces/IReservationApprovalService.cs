using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces {
    // The Reservations submodule's calls (§10.4.2, §10.4.5). None of them is CRUD in the
    // BaseApiService<T> sense - the decisions carry no body and are checked against the
    // logged-in user's Position server-side - so this is its own small interface rather
    // than reusing IApiService<T>.
    public interface IReservationApprovalService {
        Task<HttpResponseModel<IEnumerable<PendingReservationModel>>> GetPendingAsync();

        // Every reservation: at-limit questions first, then pending, approved and declined.
        Task<HttpResponseModel<IEnumerable<PendingReservationModel>>> GetQueueAsync();

        Task<HttpResponseModel<object>> ApproveAsync(uint reservationId);

        Task<HttpResponseModel<object>> RejectAsync(uint reservationId);

        Task<HttpResponseModel<object>> RemoveAsync(uint reservationId);

        Task<HttpResponseModel<object>> KeepOnHoldAsync(uint reservationId);

        Task<HttpResponseModel<object>> LetGoAsync(uint reservationId);
    }
}
