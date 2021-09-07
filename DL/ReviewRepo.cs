using System.Linq;
using System;
using System.Collections.Generic;
using DL.Entities;


namespace DL
{
    public class ReviewRepo : IReviewRepo
    {
        private MyTestContext _context;
        public ReviewRepo(MyTestContext context)
        {
            _context = context;
        }


        public List<Models.Reviews> GetAvgRatings(int id) {
            Console.WriteLine("Searching for average...");
            return _context.Reviews.Where(reviews => reviews.RestaurantId == id)
            .Select(
                review => new Models.Reviews(review.Rating, review.Content, review.RestaurantId)
            )
            .ToList();
        }


        //Search for restaurant by name
        public Models.Restaurant GetRestaurantByName(string name)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
            .FirstOrDefault(restaurant => restaurant.Name == name);
            if (foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Name, foundRestaurant.Zipcode, foundRestaurant.Street, foundRestaurant.Cuisine);
            }
            return new Models.Restaurant();

        }
        //Search for restaurant by id
        public Models.Restaurant GetRestaurantById(int id)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
            .FirstOrDefault(restaurant => restaurant.Id == id);
            if (foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Name, foundRestaurant.Zipcode, foundRestaurant.Street, foundRestaurant.Cuisine);
            }
            return new Models.Restaurant();
        }
        public Models.Users GetUserById(int id)
        {
            Entities.User foundUser = _context.Users
            .FirstOrDefault(user => user.Id == id);
            Console.WriteLine($"Id {id}");
            try {
                return new Models.Users(foundUser.Name, foundUser.UserName, foundUser.Password, foundUser.Id);
            } catch (NullReferenceException)
            {
                return null;
            }
        }

        public Models.Restaurant RestaurantLookupZip(string zipcode)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
            .FirstOrDefault(restaurant => restaurant.Zipcode == zipcode);
            if (foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Name, foundRestaurant.Zipcode, foundRestaurant.Street, foundRestaurant.Cuisine);
            }
            return new Models.Restaurant();

        }


        public Models.Reviews AddAReview(Models.Reviews review)
        {
            _context.Reviews.Add(
                new Entities.Review {
                    Rating = review.Rating,
                    Content = review.Content,
                    RestaurantId = review.RestaurantId
                }
            );
            _context.SaveChanges();

            return review;
        }

/// <summary>
/// Methods used for P1. Other needs to be removed
/// </summary>
/// <param name="userName"></param>
/// <returns></returns>

        public List<Models.Reviews> GetReviewsByRestaurantId(int restaurantId)
        {
            return _context.Reviews.Where(reviews => reviews.RestaurantId == restaurantId)
            .Select(
                review => new Models.Reviews(review.Rating, review.Content, review.RestaurantId)
            )
            .ToList();
        }


        public Models.Users GetUserPassword(string userName)
        {
            Entities.User foundUser = _context.Users.FirstOrDefault(
                foundUser => foundUser.UserName == userName
            );
            if (foundUser != null)
            {
                return new Models.Users(foundUser.Name, foundUser.UserName, foundUser.Password);
            }
            return new Models.Users();
        }

        public string GetAdminPassword()
        {
            Entities.Admin foundAdmin = _context.Admins.FirstOrDefault(
                foundAdmin => foundAdmin.Id == 1
            );
            return foundAdmin.Password;

        }

        public bool GetUserName(string userName)
        {
            Entities.User foundUser = _context.Users.FirstOrDefault(
                foundUser => foundUser.UserName == userName
            );
            if (foundUser != null)
            {
                return true;
            }
            return false;
        }



        public bool LoginWebApp(string username, string password)
        {
            try
            {
                Entities.User foundUser = _context.Users
                .FirstOrDefault(users => users.Name == username);
                if (foundUser != null)
                {
                    if (foundUser.Password == password)
                    {
                        return true;
                    }
                }

            }//end try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// "Get obj" methods
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public Models.Users GetUserObj(string userName)
        {
            Entities.User foundUser = _context.Users
            .FirstOrDefault(users => users.Name == userName);
            if (foundUser != null)
            {
                return new Models.Users(foundUser.Name, foundUser.UserName, foundUser.Password, foundUser.Id);
            }
            return new Models.Users();
        }

        public Models.Restaurant GetRestaurantObj(string name)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
            .FirstOrDefault(restaurant => restaurant.Name == name);
            if (foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Name, foundRestaurant.Zipcode, foundRestaurant.Street, foundRestaurant.Cuisine);
            }
            else
            {
                return null;
            }

        }

        public Models.Reviews GetReviewObj(int id)
        {
            Entities.Review foundReview = _context.Reviews
            .FirstOrDefault(review => review.Id == id);
            if (foundReview != null)
            {
                return new Models.Reviews(foundReview.Id, foundReview.Rating, foundReview.Content, foundReview.RestaurantId, foundReview.UserId);
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// "Get all" methods
        /// </summary>
        /// <returns></returns>
        public List<Models.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.Select(
                restaurant => new Models.Restaurant(restaurant.Name, restaurant.Zipcode, restaurant.Street, restaurant.Cuisine)
            ).ToList();
        }

        public List<Models.Users> GetAllUsers()
        {
            return _context.Users.Select(
                users => new Models.Users(users.Name, users.UserName, users.Password, users.Id)
            ).ToList();
        }

        public List<Models.Reviews> GetAllReviews()
        {
            return _context.Reviews.Select(
                reviews => new Models.Reviews(reviews.Rating, reviews.Content, reviews.RestaurantId)
            ).ToList();
        }


        /*
         --------------------------------------------
        CRUD methods for P1
        ---------------------------------------------
         */

        ///Restaurant
        public void CreateRestaurant(Models.Restaurant restaurant)
            {
                var entity = new Entities.Restaurant { Name = restaurant.Name, Zipcode = restaurant.ZipCode, Street = restaurant.Street, Cuisine = restaurant.Cuisine };
                _context.Restaurants.Add(entity);
                _context.SaveChanges();
            }

            public void DeleteRestaurant(string id)
            {
                var entity = _context.Restaurants.First(rest => rest.Id == Convert.ToInt32(id));
                _context.Remove(entity);
                _context.SaveChanges();
            }

        ///Users
        public void CreateUser(Models.Users user)
        {
            _context.Users.Add( new Entities.User { Name = user.Name, UserName = user.UserName,Password = user.Password });
            _context.SaveChanges();
        }

        /// <summary>
        ///   Users can change password
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(string id, Models.Users user)
            {
            Entities.User foundUser = _context.Users.FirstOrDefault(
            foundUser => foundUser.Name == id);
            foundUser.Password = user.Password;
                _context.SaveChanges();
            }

         public void DeleteUser(string name)
         {
              var entity = _context.Users.First(u => u.Name == name);
              _context.Remove(entity);
              _context.SaveChanges();
         }

        /// Reviews
        public void CreateReview(Models.Reviews review) 
        { 
            _context.Reviews.Add(new Entities.Review{ Rating = review.Rating, Content = review.Content, RestaurantId = review.RestaurantId });
            _context.SaveChanges();
        }
        /// <summary>
        /// Able to update content and rating of review
        /// </summary>
        /// <param name="review"></param>
        public void UpdateReview(int id, Models.Reviews review)
            {
                var foundReview = _context.Reviews.First(r => r.Id == id);
                foundReview.Content = review.Content;
                foundReview.Rating = review.Rating;
                _context.SaveChanges();
            }

        public void DeleteReview(int id)
        {
            var entity = _context.Users.First(rev => rev.Id == id);
            _context.Remove(entity);
            _context.SaveChanges();
        }


    }
}