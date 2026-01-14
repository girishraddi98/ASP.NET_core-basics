using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Principal;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task<IActionResult> GetAccountFromApp1()
    {
        var response = await _httpClient.GetAsync("https://localhost:7165/");

        if (!response.IsSuccessStatusCode)
            return BadRequest("Error calling API");

        var account = await response.Content.ReadFromJsonAsync<Account>();
        return Ok(account);
    }
}

