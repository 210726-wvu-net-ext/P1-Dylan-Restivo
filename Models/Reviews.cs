using System;

namespace Models
{
    public class Reviews
    {
        public Reviews(){}
        public Reviews(int rating, string content, int restaurantId){
            this.Rating = rating;
            this.Content = content;
            this.RestaurantId = restaurantId;
        }
        public Reviews(int rating, string content, int restaurantId, int userId){
            this.Rating = rating;
            this.Content = content;
            this.RestaurantId = restaurantId;
            this.UserId = userId;
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        
    }
}