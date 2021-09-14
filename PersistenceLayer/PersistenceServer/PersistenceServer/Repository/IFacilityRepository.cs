using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IFacilityRepository
    {
        Task<Facility> GetFacilityWithIdAsync(int id);
    }
}