using System;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface ILoginService
    {
        Task<Account> ValidateAccountAsync(string username, string passwordHashed);
    }
    
}