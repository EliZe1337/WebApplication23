using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication23.Controllers
{
    public class LoginViewModel
    {
        public int Id { get; set; } 
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
        public int logid { get; set; }
    }
}
