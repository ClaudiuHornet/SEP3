using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class TransactionService : ITransactionService
    {
        public async Task<Transaction> SendTransactionAsync(Transaction transaction)
        {
            Console.WriteLine($"{transaction.SenderAccount}");
            string json = ToJson(transaction);

            HttpContent content = new StringContent(
                json, Encoding.UTF8, "application/json");

            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/transaction/maketransaction", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
            }
            
            string readAsStringAsync = await response.Content.ReadAsStringAsync();
            Console.WriteLine(readAsStringAsync);
            return ToObject<Transaction>(readAsStringAsync);
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