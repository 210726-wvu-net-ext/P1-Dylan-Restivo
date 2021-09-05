using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels
{
    public class RestaurantViewModel
    {
            [Display(Name = "Name")]
            [Required, RegularExpression("[A-Z].*")]
            public string Name { get; set; }

            [Display(Name = "Zipcode")]
            [Required]
            public string ZipCode { get; set; }

            [Display(Name = "Address")]
            [Required]
            public string Street { get; set; }

            [Display(Name = "Cuisine")]
            [Required]
            public string Cuisine { get; set; }
    }
}
