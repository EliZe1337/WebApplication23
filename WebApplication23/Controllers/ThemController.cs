using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication23.Database;

namespace WebApplication23.Controllers
{
    public class ThemController : Controller
    {
        private readonly Ithemrep _repository;
        public ThemController(Ithemrep rep)
        {
            _repository = rep;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ThemViewModel model)
        {
            await _repository.Create(model);
            return Redirect("/Them/ShwAllUser");
    
        }
       
        public async Task<IActionResult> ShwAllUser()
        {
            var users = await _repository.Select();

            return View(users);
        }
        public async Task<IActionResult> GetThem(int id)
        {
            var them = await _repository.GetById(id);
            return View(them);
        }

        public async Task<IActionResult> GetFile(int id)
        {
            var them = await _repository.GetById(id);
            string file_path = them.Path;
            string file_type = "exe/plain";

            string file_name = "m.exe";
            return PhysicalFile(file_path, file_type, file_name);
        }
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var them = await _repository.GetById(id);
            return View(them);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ThemViewModel model)
        {
            await _repository.Edit(model);
            return Redirect("/Them/ShwAllUser");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Redirect("/Them/ShwAllUser");
        }
            
    }
}
