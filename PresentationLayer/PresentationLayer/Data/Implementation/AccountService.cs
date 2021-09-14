using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;
using PresentationLayer.Utils;

namespace PresentationLayer.Data.Implementation
{
    public class AccountService : IAccountService
    {
        public async Task<ViaEntity> CheckViaAccountAsync(ViaEntity entityToCheck)
        {
            string hashedPassword = HashingUtils.GetHash(entityToCheck.Password);
            
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"http://localhost:8080/account?id={entityToCheck.ViaId}&password={hashedPassword}");
            

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"{responseMessage.Content.ReadAsStringAsync().Result}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            ViaEntity viaEntity;

            if (result.Contains("cpr"))
            {
                viaEntity = JsonSerializer.Deserialize<Models.Member>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                viaEntity = JsonSerializer.Deserialize<Models.Facility>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return viaEntity;
        }

        public async Task CreateAccountAsync(Account account)
        {
            string hashedPassword = HashingUtils.GetHash(account.ApplicationPassword);
            Account accountToSend = new Account()
            {
                AccountType = account.AccountType,
                ApplicationPassword = hashedPassword,
                ViaEntity = account.ViaEntity
            };


            HttpClient client = new HttpClient();

            string accountAsJson = JsonSerializer.Serialize(accountToSend, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Console.WriteLine(accountAsJson);

            StringContent content = new StringContent(
                accountAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8080/account", content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"{responseMessage.Content.ReadAsStringAsync().Result}");
            }
        }
    }
    
    
}