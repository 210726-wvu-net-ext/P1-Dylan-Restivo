using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class SignInModel
    {

        [Display(Name = "User Name")]
        [Required, RegularExpression("[A-Z].*")]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
