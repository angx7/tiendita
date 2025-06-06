using System.Net.Http.Headers;
using System.Text;
using _411_tiendita.Models;
using Newtonsoft.Json;

namespace _411_tiendita.services;

public class AuthService
{
    // Paquete nugget 
    private readonly HttpClient _httpClient;
    private const String BaseUrl = "https://a453-2a09-bac5-4b0a-63c-00-9f-29.ngrok-free.app/api";

    public AuthService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<bool> Login(string email, string password)
    {
        try
        {
            var requestData = new { email, password };
            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, @"application/json");
            
            var response = await _httpClient.PostAsync($"{BaseUrl}/auth/login", content);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthResponse>(responseContent);

            if (result?.Success == true)
            {
                Preferences.Set("user", result.Usuario.Nombre);
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
}