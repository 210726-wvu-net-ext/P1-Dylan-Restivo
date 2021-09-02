using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "User Name")]
        [Required, RegularExpression("[A-Z].*")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
