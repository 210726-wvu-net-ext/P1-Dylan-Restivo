using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels
{
    public class ReviewsViewModel
    {

        [Display(Name = "Rating")]
        [Required, RegularExpression("[1-5]")]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        [Required]
        public string Content { get; set; }

        public DateTime ReviewDate { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }


    }
}
