using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication23.Controllers;

namespace WebApplication23.Database
{
    public interface IUserrep
    {
        Task<List<ThemViewModel>> ShwAllThem();

        Task<LoginViewModel> Create(LoginViewModel model);
        Task<int> Loggging(string name);
        Task<LoginViewModel> GetByName(string name);
    }
}
