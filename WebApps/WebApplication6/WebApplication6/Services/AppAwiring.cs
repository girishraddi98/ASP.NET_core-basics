namespace WebApplication6.Services
{
    public class AppAService
    {
        private readonly HttpClient _httpClient;

        public AppAService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDataFromAppA()
        {
            

            var response = await _httpClient.GetAsync("https://localhost:7251/api/values");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}
