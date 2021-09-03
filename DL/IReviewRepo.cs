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

        Restaurant RestaurantLookupZip(string zipcode);

        List<Models.Reviews> GetReviewsByRestaurantId(int restaurantId);

        Restaurant GetRestaurantForAdd(string name);

        Users GetUserPassword(string userName);

        string GetAdminPassword();

        Users GetUserById(int id);

        bool GetUserName(string userName);

        bool LoginWebApp(string username, string password);

        Users GetUserObj(string username);

        void DeleteUser(string username);

        void CreateUser(Users user);

        void UpdateUser(Users user);
    }
}