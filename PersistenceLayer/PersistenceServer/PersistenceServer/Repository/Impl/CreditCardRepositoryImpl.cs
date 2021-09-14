using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class CreditCardRepositoryImpl : ICreditCardRepository
    {
        public async Task AddCreditCardToAccount(CreditCard creditCard)
        {
            await using DataContext dataContext = new DataContext();
            try
            {
                Account account =
                  await  dataContext.Accounts.FirstAsync(x => x.AccountId.Equals(creditCard.Account.AccountId));
                creditCard.Account = account;
                Console.WriteLine(creditCard.CreditCardNumber);
                Console.WriteLine(creditCard.Account.AccountId);
                Console.WriteLine(creditCard.Account.ApplicationPassword);
                await dataContext.CreditCards.AddAsync(creditCard);
                await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"This credit card cannot be added!");
            }
        }

        public async Task<bool> CheckCreditCard(int id)
        {
            await using DataContext dataContext = new DataContext();
            Console.WriteLine("It got to repository");
            CreditCard creditCard = dataContext.CreditCards.FirstOrDefault(c => c.Account.AccountId.Equals(id));
            Console.WriteLine("checked credit card");
            if (creditCard != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DepositMoney(Account account)
        {
            await using DataContext dataContext = new DataContext();
            Console.WriteLine("It got to repository deposit money, account id : " + account.AccountId);
            CreditCard creditCard = dataContext.CreditCards.FirstOrDefault(c => c.Account.AccountId.Equals(account.AccountId));
            if (creditCard != null && creditCard.AmountOfMoney >= account.Balance)
            {
                Console.WriteLine("got after the first if");
                Account accountToEdit = dataContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(account.AccountId));
                if (accountToEdit != null)
                {
                    Console.WriteLine("Got after the second if " + accountToEdit.AccountId);
                    creditCard.AmountOfMoney -= account.Balance;
                    accountToEdit.Balance += account.Balance;
                    dataContext.Accounts.Update(accountToEdit);
                    await dataContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Account not found");
                }
            }
            return false;
        }
    }
}