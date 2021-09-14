using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class ViaEntityRepositoryImpl : IViaEntityRepository
    {
        public async Task<ViaEntity> GetViaEntityWithIdAsync(int id)
        {
            using DataContext dataContext = new DataContext();
            ViaEntity viaEntity;

            try
            {
                viaEntity = await dataContext.ViaEntities.FirstAsync(ve => ve.ViaId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Via entity with id: {id} could not be found");
            }
            return viaEntity;
        }
    }
}