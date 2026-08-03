using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IItemBinLocation<T> : IGetByIdService<T>
    {
        // Deliberately hides IGetByIdService<T>.GetAsync(int): this interface always
        // returns ItemBinLocationModel rows regardless of T, rather than List<T> -
        // the "new" here just tells the compiler that's intentional, not an accident.
        new Task<HttpResponseModel<List<ItemBinLocationModel>>> GetAsync(int itemId);
    }
}
