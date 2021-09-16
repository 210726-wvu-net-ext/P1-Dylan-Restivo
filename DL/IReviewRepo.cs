using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IReviewRepo
    {
        List<Restaurant> GetAllRestaurants();

        List<Users> GetAllUsers();
    
        List<Reviews> GetAllReviews();

        List<Reviews> GetAvgRatings(int id);

        Restaurant GetRestaurantById(int id);

        Restaurant RestaurantLookupZip(string zipcode);

        List<Models.Reviews> GetReviewsByRestaurantId(int restaurantId);


        Users GetUserPassword(string userName);

        string GetAdminPassword();

        Models.Users GetUserById(int id);

        bool GetUserName(string userName);

        bool LoginWebApp(string username, string password);

        Users GetUserObj(string name);

        Restaurant GetRestaurantObj(string name);

        void DeleteRestaurant(string username);

        void CreateUser(Users user);

        void UpdateUser(string id, Users user);

        void CreateRestaurant(Restaurant restaurant);
        void CreateReview(Reviews review);

        Reviews GetReviewObj(int id);

        void UpdateReview(int id, Reviews review);

        void DeleteReview(int id);


        //void UpdateRestaurant(string id, Restaurant restaurant);
    }
}