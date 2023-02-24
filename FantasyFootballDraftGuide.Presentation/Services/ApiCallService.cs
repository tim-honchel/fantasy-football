using FantasyFootballDraftGuide.API.ViewModels;
using System.Net;
using System.Net.Http.Headers;

namespace FantasyFootballDraftGuide.Presentation.Services
{
    public class ApiCallService : IApiCallService
    {
        private static HttpClient? _client;
        public ApiCallService() 
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7117/");
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ApiCallService(HttpMessageHandler handler) 
        {
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri("https://localhost:7118/");
        }

        public async Task SubmitLeagueRules(RulesViewModel rules)
        {
            var response = await _client.PostAsJsonAsync("Rules", rules);

            if (response.StatusCode == HttpStatusCode.OK) { return; }
            else if (response.StatusCode == HttpStatusCode.BadRequest) { throw new ArgumentOutOfRangeException(nameof(rules), "Please check that all rules were entered correctly."); }
            else { throw new Exception(); }
        }
    }
}
