using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface ICreditCardRepository
    {
        Task AddCreditCardToAccount(CreditCard creditCard);
        Task<bool> CheckCreditCard(int id);
        Task<bool> DepositMoney(Account account);
    }
}