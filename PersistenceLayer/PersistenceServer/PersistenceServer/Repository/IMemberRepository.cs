using System.Threading.Tasks;
using PersistenceServer.Models;

namespace PersistenceServer.Repository
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberWithIdAsync(int id);
    }
}