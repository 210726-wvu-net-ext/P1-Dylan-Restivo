using System;
using System.ComponentModel.DataAnnotations;


namespace WebApp.ViewModels
{
    public class RestReviewViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Cuisine { get; set; }

        public int Rating { get; set; }
        public String Content { get; set; }

    }
}
