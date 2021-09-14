using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<string> AddCreditCardToAccount(CreditCard creditCardFromPage)
        {
           
            HttpClient client = new HttpClient();
            String creditcard = JsonSerializer.Serialize(creditCardFromPage, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Uri u = new Uri("http://localhost:8080/creditcard/addcreditcard");
            HttpContent c = new StringContent(creditcard, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(u, c);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
            }

            if (response.Content.ReadAsStringAsync().Result.Equals("Provided credit card information is invalid"))
            {
                return "";
            }
            else
            {
                return "Card Added Successfully!";
            }
           
        }
        
        public async Task<bool> CheckCreditCard(int id)
            {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcard/checkcreditcard/{id}");

            Console.WriteLine("it got here");
            
                if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
                
            string result = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine("Response got to service");
            
            bool response = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            Console.WriteLine("response deserialized");
                return response;
            }
        
            public async Task<bool> DepositMoney(Account account)
            {
                HttpClient client = new HttpClient();
                string todoAsJson = JsonSerializer.Serialize(account, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                HttpContent content = new StringContent(todoAsJson,
                    Encoding.UTF8,
                    "application/json");
                HttpResponseMessage responseMessage =
                    await client.PatchAsync("http://localhost:8080/creditcard/depositmoney", content);
                
                 if (!responseMessage.IsSuccessStatusCode)
                 {
                     throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
                 }
                
                string result = await responseMessage.Content.ReadAsStringAsync();

                bool response = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("response deserialized");
                return response;
                

            }
        
    }
    
    
}