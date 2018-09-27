using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactorySample.GitHub
{
    #region snippet1
    public class RepoService
    {
        // _httpClient isn't exposed publicly
        private readonly HttpClient _httpClient;

        public RepoService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<string>> GetRepos()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("aspnet/repos");

            response.EnsureSuccessStatusCode();

            IEnumerable<string> result = await response.Content
                .ReadAsAsync<IEnumerable<string>>();

            return result;
        }
    }
    #endregion
}