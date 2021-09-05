using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels
{
    public class ReviewsViewModel
    {
        [Display(Name = "Restaurant Address")]
        [Required]
        public string Street { get; set; }

        [Display(Name = "Rating")]
        [Required, RegularExpression("[1-5].*")]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }
    }
}
