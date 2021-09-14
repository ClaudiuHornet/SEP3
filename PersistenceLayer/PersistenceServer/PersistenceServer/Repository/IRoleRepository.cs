using System.Collections.Generic;
using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IRoleRepository
    {
        Task<List<string>> GetAllAccountTypesAsync();
        Task<Role> GetRoleWithTypeAsync(string roleType);
    }
}