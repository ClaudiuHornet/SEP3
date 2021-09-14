using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class TransactionRepositoryImpl : ITransactionRepository
    {
        public async Task<Account> GetAccountByAccountID(int accountid)
        {
            try
            {
                using DataContext dataContext = new DataContext();
                Account account = await dataContext.Accounts.FirstAsync(x => x.AccountId == accountid);
                return account;
            }
            catch (Exception e)
            {
                throw new Exception("Account could not be updated");
            }
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            await using DataContext dataContext = new DataContext();

            try
            {
                Account sender =
                    await dataContext.Accounts.FirstOrDefaultAsync(a => a.AccountId == transaction.SenderAccount.AccountId);

                Account receiver =
                    await dataContext.Accounts.FirstOrDefaultAsync(a =>
                        a.AccountId == transaction.ReceiverAccount.AccountId);

                transaction.ReceiverAccount = receiver;
                transaction.SenderAccount = sender;

                EntityEntry<Transaction> entityEntry = await dataContext.Transactions.AddAsync(transaction);
                Transaction transactionAdded = entityEntry.Entity;

                await dataContext.SaveChangesAsync();
                return transactionAdded;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw new Exception("Transaction could not be added");
            }
        }
    }
}