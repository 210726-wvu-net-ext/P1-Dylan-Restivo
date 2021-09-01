using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IReviewBL
    {
         List<Restaurant> ViewAllRestaurants();

         List<Users> ViewAllUsers();
         List<Reviews> ViewAllReviews();

         List<Reviews> AvgReviewRatings(int id);

         Restaurant RestaurantLookupName(string name);
         Restaurant RestaurantLookupId(int restaurantId);

         Users UserLookupName(int userId);

         Restaurant RestaurantLookupZip(string zipcode);

         List <Reviews> SearchReviewsByRestaurantId(int restaurantId);

         Reviews AddReview(Reviews reviewToAdd);

         Users AddUser(Users userToAdd);

         Restaurant RestaurantLookupNameForReviewAdd(string name);

         Users PasswordVerifyUser(string userName);

         string PasswordVerifyAdmin();

         bool CheckUserName(string userName);

         Users CheckUserId(string userName);

    }
}