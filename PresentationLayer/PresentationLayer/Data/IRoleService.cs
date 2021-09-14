using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationLayer.Data
{
    public interface IRoleService
    {
        Task<List<string>> GetAllAccountTypesAsync();
    }
}