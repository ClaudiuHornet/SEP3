using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data
{
    public interface IAccountService
    {
        Task<ViaEntity> CheckViaAccountAsync(ViaEntity entityToCheck);

        Task CreateAccountAsync(Account account);
    }
}