using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication23.Controllers;

namespace WebApplication23.Database
{
    public class repository : IUserrep
    {
        public readonly ApplicationDBcontext _db;
        public repository(ApplicationDBcontext db)
        {
            _db = db;
        }
        public async Task<LoginViewModel> Create(LoginViewModel model)
        {
            LoginViewModel l = new LoginViewModel()
            {
                UserName = model.UserName,
                Password = model.Password,
                logid = 0,
                ReturnUrl = "/Admin"
            };
            
            await _db.Users.AddAsync(l);
            
            await _db.SaveChangesAsync();
            return null;
            //проверка на логирование
            
            
        }
        public async Task<LoginViewModel> GetByName(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<int> Loggging(string name)
        {
            var t = await GetByName(name);
            if(t.logid == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

            //if(t != null)
            //{
            //    return false;
            //}
            //return true;
        }
        public async Task<List<ThemViewModel>> ShwAllThem()
        {
            return await _db.them.ToListAsync();
        }



        public async Task<List<LoginViewModel>> ShwAllUser()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
