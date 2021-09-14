using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IViaEntityRepository
    {
        Task<ViaEntity> GetViaEntityWithIdAsync(int id);
    }
}