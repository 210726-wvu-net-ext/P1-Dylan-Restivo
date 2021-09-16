using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Reviews
    {
        public Reviews(){}
        public Reviews(int rating, string content)
        {
            this.Rating = rating;
            this.Content = content;
            this.Date = DateTime.Now;
        }
        public Reviews(int rating, string content, int restaurantId){
            this.Rating = rating;
            this.Content = content;
            this.RestaurantId = restaurantId;
            this.Date = DateTime.Now;
        }
        public Reviews(int rating, string content, int restaurantId, int userId){
            this.Rating = rating;
            this.Content = content;
            this.RestaurantId = restaurantId;
            this.UserId = userId;
            this.Date = DateTime.Now;
        }
        public Reviews(int id, int rating, string content, int restaurantId, int userId)
        {
            this.Id = id;
            this.Rating = rating;
            this.Content = content;
            this.RestaurantId = restaurantId;
            this.UserId = userId;
            this.Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string RestaurantName { get; set; }

    }
}