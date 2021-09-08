using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Name")]
        [Required, RegularExpression("^[a-zA-Z]*$")]
        public string Name { get; set; }

        [Display(Name = "Username")]
        [Required, RegularExpression("[A-Z].*")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public int Id { get; set; }

    }
}
