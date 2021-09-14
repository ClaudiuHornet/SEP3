using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class FacilityRepositoryImpl : IFacilityRepository
    {
        public async Task<Facility> GetFacilityWithIdAsync(int id)
        {
            using DataContext dataContext = new DataContext();

            Facility facility = await dataContext.Facilities.FirstOrDefaultAsync(f => f.ViaId == id);
            return facility;
        }
    }
}