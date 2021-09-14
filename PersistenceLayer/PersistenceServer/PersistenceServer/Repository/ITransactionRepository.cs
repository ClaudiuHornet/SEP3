using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface ITransactionRepository
    {
        Task<Account> GetAccountByAccountID(int accountid);
        Task<Transaction> AddTransaction(Transaction transaction);
    }
}