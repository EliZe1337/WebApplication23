using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication23.Database
{
    public class thremrepository : Ithemrep
    {
        public ApplicationDBcontext db;
        public thremrepository(ApplicationDBcontext ddb)
        {
            db = ddb;
        }
        public async Task<ThemViewModel> Create(ThemViewModel model)
        {
            await db.them.AddAsync(model);
            await db.SaveChangesAsync();
            return null;
        }

        public async Task<ThemViewModel> GetById(int id)
        {
            return await db.them.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ThemViewModel> Edit(ThemViewModel model)
        {
            var them = await db.them.FirstOrDefaultAsync(x => x.Id == model.Id);
            them.src_ph = model.src_ph;
            them.Name = model.Name;
            them.Path = model.Path;
            them.deskription = model.deskription;   
            them.FullDeskription = model.FullDeskription;
            db.them.Update(them);
            await db.SaveChangesAsync();
            return null;
        }

        public async Task<List<ThemViewModel>> Select()
        {
            return await db.them.ToListAsync();
        }

        public async Task<ThemViewModel> Delete(int id)
        {
            var them = await GetById(id);
            db.them.Remove(them);
            await db.SaveChangesAsync();
            return null;    
        }
    }
}
