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

        Restaurant GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int id);

        Users GetUserById(int id);

        Restaurant RestaurantLookupZip(string zipcode);

        List<Models.Reviews> GetReviewsByRestaurantId(int restaurantId);

        Reviews AddAReview(Reviews review);

        Users AddAUser(Users AddAUser);

        Restaurant GetRestaurantForAdd(string name);

        Users GetUserPassword(string userName);

        string GetAdminPassword();

        bool GetUserName(string userName);

        Users GetUserId(string username);
    }
}