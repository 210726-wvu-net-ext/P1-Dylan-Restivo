using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class usernameSearchViewModel
    {
        public List<Users> Users { get; set; }
        public SelectList UserNames { get; set; }
        public string UserName { get; set; }
        public string SearchString { get; set; }

    }
}
