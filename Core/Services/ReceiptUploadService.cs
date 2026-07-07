using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class ReceiptUploadService : IReceiptUploadService
    {
        private readonly IHttpService _httpService;

        public ReceiptUploadService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<ReceiptUploadModel>> UploadAsync(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            using (var fileStream = File.OpenRead(filePath))
            {
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent, "file", Path.GetFileName(filePath));

                return await _httpService.PostMultipartAsync<HttpResponseModel<ReceiptUploadModel>>("uploads/receipts", content);
            }
        }
    }
}
