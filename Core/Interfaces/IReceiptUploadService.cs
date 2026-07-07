using smpc_dispatching.Core.Models;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IReceiptUploadService
    {
        Task<HttpResponseModel<ReceiptUploadModel>> UploadAsync(string filePath);
    }
}
