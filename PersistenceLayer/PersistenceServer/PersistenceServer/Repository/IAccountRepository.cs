using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<Account> GetAccountWithViaId(int viaId);
        Task AddAccountAsync(Account accountToAdd);
        Task<Account> UpdateAccount(Account accountToUpdate);
    }
}