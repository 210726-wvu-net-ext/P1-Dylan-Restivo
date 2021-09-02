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
        public List<Models.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.Select(
                restaurant => new Models.Restaurant(restaurant.Id, restaurant.Name, restaurant.Zipcode)
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
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Name, foundRestaurant.Zipcode);
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
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Name, foundRestaurant.Zipcode);
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
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Name, foundRestaurant.Zipcode);
            }
            return new Models.Restaurant();

        }

        public List<Models.Reviews> GetReviewsByRestaurantId(int restaurantId)
        {
            Console.WriteLine("Searching for reviews...");
            return _context.Reviews.Where(reviews => reviews.RestaurantId == restaurantId)
            .Select(
                review => new Models.Reviews(review.Rating, review.Content, review.RestaurantId)
            )
            .ToList();
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

        public Models.Users AddAUser(Models.Users userToAdd) {
            _context.Users.Add(
                new Entities.User {
                    Name = userToAdd.Name,
                    UserName = userToAdd.UserName,
                    Password = userToAdd.Password
                }
            );
            _context.SaveChanges();

            return userToAdd;
        }

        public Models.Restaurant GetRestaurantForAdd(string name)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
            .FirstOrDefault(restaurant => restaurant.Name == name);
            if (foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Name, foundRestaurant.Zipcode);
            } else {
                return null;
            }

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

        public Models.Users GetUserId(string userName)
        {
            Entities.User foundUser = _context.Users
            .FirstOrDefault(users => users.Name == userName);
            if (foundUser != null)
            {
                return new Models.Users(foundUser.Name, foundUser.UserName, foundUser.Password, foundUser.Id);
            }
            return new Models.Users();
        }

        public bool LoginWebApp(string username, string password)
        {
            try {
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

    }
}