using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class SignUpModel : Controller
    {

            [Required]
            public string name { get; set; }

            [Required]
            public string username { get; set; }

            [Required]
            public string password { get; set; }
     
    }
}
