using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication23.Database
{
    public interface Ithemrep
    {
        public Task<ThemViewModel> Delete(int id);
        public Task<ThemViewModel> Create(ThemViewModel model);
        public Task<List<ThemViewModel>> Select();
        public Task<ThemViewModel> GetById(int id);
        public Task<ThemViewModel> Edit(ThemViewModel model);
    }
}
