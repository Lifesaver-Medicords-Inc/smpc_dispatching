using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    interface IItemStockAndLocationService<T> : IGetByIdService<T>
    {
    }
}
