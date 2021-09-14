using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            Console.WriteLine($"Username from handler: {username}");
            await using DataContext dataContext = new DataContext();
            Account account;
            try
            {
                account = await dataContext.Accounts.Include(c => c.ViaEntity).Include(a => a.AccountType)
                    .FirstAsync(a => a.ViaEntity.ViaId.ToString().Equals(username));
            }
            catch (Exception e)
            {
                throw new Exception($"Account with username {username} could not be found");
            }

            Console.WriteLine($"Account found username:{account.ViaEntity.ViaId}");
            Console.WriteLine($"Account found AccountID:{account.AccountId}");
            Console.WriteLine($"Account found password:{account.ApplicationPassword}");
            Console.WriteLine($"Account found with role:{account.AccountType.RoleType}");
            Console.WriteLine(account);

            return account;
        }

        public async Task<Account> GetAccountWithViaId(int viaId)
        {
            Console.WriteLine($"*** looking for account with id: {viaId}");
            using DataContext dataContext = new DataContext();
            Account account;
            try
            {
                account = await dataContext.Accounts.FirstAsync(a => a.ViaEntity.ViaId == viaId);
            }
            catch (Exception e)
            {
                throw new Exception($"Not found. Please check credentials");
            }

            return account;
        }

        public async Task AddAccountAsync(Account accountToAdd)
        {
            using DataContext dataContext = new DataContext();

            try
            {
                Role r = await dataContext.Roles.FirstOrDefaultAsync(r => r.RoleId == accountToAdd.AccountType.RoleId);
                accountToAdd.AccountType = r;

                ViaEntity ve =
                    await dataContext.ViaEntities.FirstOrDefaultAsync(ve => ve.ViaId == accountToAdd.ViaEntity.ViaId);
                accountToAdd.ViaEntity = ve;

                await dataContext.Accounts.AddAsync(accountToAdd);
                await dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Account was not created");
            }
        }

        public async Task<Account> UpdateAccount(Account accountToUpdate)
        {
            using DataContext dataContext = new DataContext();

            try
            {
                EntityEntry<Account> entityEntry = dataContext.Accounts.Update(accountToUpdate);
                await dataContext.SaveChangesAsync();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                throw new Exception("Account could not be updated");
            }
        }
    }
}