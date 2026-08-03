using smpc_dispatching.Core.Models;

namespace smpc_dispatching.Core.Interfaces
{
    // Read-only view service, same shape as ISalesOrderWithApprovedIRService<T> -
    // there is no create/update/delete for this list, it's a derived view.
    public interface IPurchasingActivePOService<T> : IGetViewService<T>
    {
    }
}
