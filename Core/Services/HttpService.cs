

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using smpc_dispatching.Core.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services {
    public class HttpService : IHttpService {
        private readonly HttpClient _client;

        private readonly IConfiguration _configuration;

        public static string SessionToken { get; set; } = "";

        public HttpService(IConfiguration configuration) {
            _configuration = configuration;

            var apiBaseUrl = _configuration["AppSettings:ApiBaseUrl"];
            if (string.IsNullOrWhiteSpace(apiBaseUrl)) {
                throw new InvalidOperationException(
                    "AppSettings:ApiBaseUrl is missing or empty. This usually means " +
                    "appsettings.{Environment}.json (matching the \"Environment\" key " +
                    "in App.config) was not found next to the running executable, or " +
                    "the running copy of the app is an old/stale install that predates " +
                    "this setting. Reinstall from the latest publish and confirm " +
                    "appsettings.Production.json / appsettings.Development.json exist " +
                    "alongside smpc_dispatching.exe.");
            }

            var handler = new HttpClientHandler {
                CookieContainer = new CookieContainer()
            };

            _client = new HttpClient(handler) {
                BaseAddress = new Uri(apiBaseUrl)
            };
        }


        private async Task<T> SendRequestAsync<T>(string url, HttpMethod method, string body = null) {
            try {

                Cursor.Current = Cursors.WaitCursor;

                HttpContent content = null;

                if (!string.IsNullOrEmpty(body) && method != HttpMethod.Get) {
                    content = new StringContent(body, Encoding.UTF8, "application/json");
                }

                var requestMessage = new HttpRequestMessage(method, url) {
                    Content = content
                };

                // Add Authorization header if token is present
                if (!string.IsNullOrWhiteSpace(SessionToken)) {
                    if (_client.DefaultRequestHeaders.Contains("Authorization"))
                        _client.DefaultRequestHeaders.Remove("Authorization");

                    _client.DefaultRequestHeaders.Add("Authorization", SessionToken);
                }

                var response = await _client.SendAsync(requestMessage);

                string responseContent = await response.Content.ReadAsStringAsync();

                // If not authenticated yet, try to get token from cookie
                if (string.IsNullOrEmpty(SessionToken) && response.Headers.Contains("Set-Cookie")) {
                    var cookies = response.Headers.GetValues("Set-Cookie").ToList();
                    string token = ExtractToken(cookies.FirstOrDefault());
                    SessionToken = token;
                }

                if (response.IsSuccessStatusCode) {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                } else {
                    Log.Warning("API request failed: {Url}, StatusCode: {StatusCode}, Response: {Response}",
                        url, response.StatusCode, responseContent);
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            } catch (Exception ex) {
                Log.Error(ex, "Exception during API request: {Url}", url);
                return default;
            } finally {
                Cursor.Current = Cursors.Default;
            }
        }

        public async Task<T> PostMultipartAsync<T>(string url, HttpContent content) {
            try {
                Cursor.Current = Cursors.WaitCursor;

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url) {
                    Content = content
                };

                if (!string.IsNullOrWhiteSpace(SessionToken)) {
                    if (_client.DefaultRequestHeaders.Contains("Authorization"))
                        _client.DefaultRequestHeaders.Remove("Authorization");

                    _client.DefaultRequestHeaders.Add("Authorization", SessionToken);
                }

                var response = await _client.SendAsync(requestMessage);

                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(SessionToken) && response.Headers.Contains("Set-Cookie")) {
                    var cookies = response.Headers.GetValues("Set-Cookie").ToList();
                    string token = ExtractToken(cookies.FirstOrDefault());
                    SessionToken = token;
                }

                if (response.IsSuccessStatusCode) {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                } else {
                    Log.Warning("API request failed: {Url}, StatusCode: {StatusCode}, Response: {Response}",
                        url, response.StatusCode, responseContent);
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            } catch (Exception ex) {
                Log.Error(ex, "Exception during API request: {Url}", url);
                return default;
            } finally {
                Cursor.Current = Cursors.Default;
            }
        }

        private static string ExtractToken(string cookieString) {
            if (string.IsNullOrEmpty(cookieString))
                return "";

            int tokenStartIndex = cookieString.IndexOf("Authorization=") + "Authorization=".Length;
            if (tokenStartIndex < "Authorization=".Length) return "";

            int tokenEndIndex = cookieString.IndexOf(";", tokenStartIndex);

            if (tokenEndIndex == -1)
                return cookieString.Substring(tokenStartIndex);

            return cookieString.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex);
        }

        public async Task<T> Get<T>(string url) => await SendRequestAsync<T>(url, HttpMethod.Get);

        public async Task<T> Post<T>(string url, object payload) {
            string json = JsonConvert.SerializeObject(payload);
            return await SendRequestAsync<T>(url, HttpMethod.Post, json);
        }

        public async Task<T> Put<T>(string url, object payload) {
            string json = JsonConvert.SerializeObject(payload);
            return await SendRequestAsync<T>(url, HttpMethod.Put, json);
        }

        public async Task<T> Delete<T>(string url, object payload = null) {
            string json = payload != null ? JsonConvert.SerializeObject(payload) : null;
            return await SendRequestAsync<T>(url, HttpMethod.Delete, json);
        }


    }
}
