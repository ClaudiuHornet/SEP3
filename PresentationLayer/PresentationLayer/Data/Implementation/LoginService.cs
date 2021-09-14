using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;
using PresentationLayer.Utils;

namespace PresentationLayer.Data.Implementation
{
    public class LoginService : ILoginService
    {
        public async Task<Account> ValidateAccountAsync(string username, string password)
        {
            Console.WriteLine($"{username} + {password}");
            string hash = HashingUtils.GetHash(password);
            Console.WriteLine($"HASHED --- {hash}");
            HttpClient client = new HttpClient();

            HttpResponseMessage response =
                await client.GetAsync($"http://localhost:8080/login?username={username}&password={hash}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
            }
            
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"result before deserialization: {result}");
            Account account = ToObject<Account>(result);
            Console.WriteLine($"Account received: {account.AccountType.RoleType}");
            return account;
        }
        
        private T ToObject<T>(String element)
        {
            var deserializeResult = JsonSerializer.Deserialize<T>(element, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return deserializeResult;
        }

        private string ToJson<T>(T objToSerialize)
        {
            string serialized = JsonSerializer.Serialize(objToSerialize, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return serialized;
        }
    }
}