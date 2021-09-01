using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class ReviewBL : IReviewBL
    {
        private IReviewRepo _repo;
        public ReviewBL(IReviewRepo repo)
        {
            _repo = repo;   
        }

        public List<Restaurant> ViewAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }

        public List<Users> ViewAllUsers()
        {
            return _repo.GetAllUsers();
        } 

        public List<Reviews> ViewAllReviews()
        {
            return _repo.GetAllReviews();
        }

        public List<Reviews> AvgReviewRatings(int restaurantId)
        {
            return _repo.GetAvgRatings(restaurantId);
        }
        public Restaurant RestaurantLookupName(string name)
        {
            return _repo.GetRestaurantByName(name);
        }

        public Restaurant RestaurantLookupId(int restaurantId)
        {
            return _repo.GetRestaurantById(restaurantId);
        }

        public Users UserLookupName(int userId)
        {
            return _repo.GetUserById(userId);
        }

        public Restaurant RestaurantLookupZip(string zipcode)
        {
            return _repo.RestaurantLookupZip(zipcode);
        }

        public List <Reviews> SearchReviewsByRestaurantId(int restaurantId)
        {
            return _repo.GetReviewsByRestaurantId(restaurantId);
        }

        public Reviews AddReview(Reviews reviewToAdd)
        {
            return _repo.AddAReview(reviewToAdd);
        }

        public Users AddUser(Users userToAdd){
            return _repo.AddAUser(userToAdd);
        }

        public Restaurant RestaurantLookupNameForReviewAdd(string name)
        {
            return _repo.GetRestaurantForAdd(name);
        }

        public Users PasswordVerifyUser(string userName)
        {
            return _repo.GetUserPassword(userName);
        }

        public string PasswordVerifyAdmin()
        {
            return _repo.GetAdminPassword();
        }

        public bool CheckUserName(string userName)
        {
            return _repo.GetUserName(userName);
        }

        public Users CheckUserId(string userName)
        {
            return _repo.GetUserId(userName);
        }

    }
}
