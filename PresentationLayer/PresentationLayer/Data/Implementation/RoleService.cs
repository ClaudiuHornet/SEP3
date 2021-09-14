using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Data.Implementation
{
    public class RoleService : IRoleService
    {
        public async Task<List<string>> GetAllAccountTypesAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"http://localhost:8080/role");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
            
            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            List<string> accountTypes = JsonSerializer.Deserialize<List<string>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return accountTypes;
        }
    }
}