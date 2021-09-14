using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class MemberRepositoryImpl : IMemberRepository
    {
        public async Task<Member> GetMemberWithIdAsync(int id)
        {
            using DataContext dataContext = new DataContext();

            Member member = await dataContext.Members.FirstOrDefaultAsync(m => m.ViaId == id);
            return member;
        }
    }
}