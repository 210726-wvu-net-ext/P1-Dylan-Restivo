using System;
using BL;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Models;

namespace UI
{

    /// <summary>
/// - add a new user 
/// - ability to search user as admin
/// - display details of a restaurant for user
/// - add reviews to a restaurant as a user
/// - view details of restaurants as a user
/// - view reviews of restaurants as a user
/// - calculate reviews’ average rating for each restaurant
/// - search restaurant (by name, rating, zip code, etc.) 
/// 
/// TODO:
/// add review should get user id and add to review
/// </summary>
    public class MainMenu : IMenu
    {
        private IReviewBL _reviewbl;
        public MainMenu(IReviewBL bL)
        {
            _reviewbl = bL;
        }
        public void Start()
        {
            do
            {
                Console.WriteLine("Welcome to EateryEvals!");
                Console.WriteLine("[0] New users");
                Console.WriteLine("[1] User login");
                Console.WriteLine("[2] Admin login");
                Console.WriteLine("[3] Exit");
                
                switch(Console.ReadLine())
                {
                    case "0":
                        AddUserUI();
                    break;

                    case "1":
                        UserLogin();
                    break;

                    case "2":
                        AdminLogin();
                    break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine();
                        Environment.Exit(0);
                    break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.WriteLine();
                    break;
                }
            }while(true);
        }
/// <summary>
/// Login as admin to search users
/// </summary>
        private void AdminLogin()
        {
            /// <summary>
            /// Loop to login and validate password
            /// </summary>
            bool flag = true;
            do{
            string adminPass = "";
            InvalidPass:
            Console.WriteLine ("Please enter the super secret admin password: ");
            try{
                adminPass = Console.ReadLine();
                string truePass = PassowrdVerifyAdminUI();
                if(truePass == adminPass){
                    flag = false;
                }
                else if(truePass != adminPass)
                {
                    Console.WriteLine("Invalid password. Check your spelling and try again.");
                    Console.WriteLine();
                    goto InvalidPass;
                }
            }
            catch(ArgumentNullException){
                Console.WriteLine("Enter a password to login.");
                Console.WriteLine();
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            }while(flag is true);
        ///
        /// Loop to provide admin functions
        /// 
            bool flag2 = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome Admin");
                Console.WriteLine("[0] Search users");
                Console.WriteLine("[1] Logout");
                
                switch(Console.ReadLine())
                {
                    case "0":
                        ViewAllUsers();
                    break;

                    case "1":
                        Console.WriteLine("Thank you! Have a good day!");
                        Console.WriteLine();
                        flag2 = false;
                    break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.WriteLine();
                    break;
                }
            }while(flag2 is true);
        }
/// <summary>
/// Function to login as user and provide options
/// </summary>

        private void UserLogin()
        {
            /// <summary>
            /// Loop to login and validate password
            /// </summary>
            bool flag = true;
            string userName = "";
            string userPass = "";
            do{
            /// <summary>
            /// Check username to see if it exists
            /// </summary>
            /// <returns></returns>
            InvalidName:
            Console.WriteLine ("Please enter your username: ");
            try{
                userName = Console.ReadLine();
                bool validateName = CheckUserNameUI(userName);
                if(validateName is true){
                    Console.WriteLine("Username validated.. Continuing:");
                    Console.WriteLine();
                    flag = false;
                }
                else if(validateName is false){
                    Console.WriteLine($"No username {userName} exists.");
                    Console.WriteLine();
                    goto InvalidName;
                }
            }
            catch(ArgumentNullException){
                Console.WriteLine("Enter a username now please.");
                Console.WriteLine();
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            }while(flag is true);
            /// <summary>
            /// Check username and password given vs DB
            /// </summary>
            /// <returns></returns>
            bool flag2 = true;
            do{
            InvalidPass:
            Console.WriteLine ($"Please enter your password {userName}: ");
            try{
                userPass = Console.ReadLine();
                string truePass = PassowrdVerifyUserUI(userName);
                if(truePass == userPass){
                    Console.WriteLine();
                    Console.WriteLine($"Login successful! Welcome {userName}");
                    flag2 = false;
                }
                else if(truePass != userPass){
                    Console.WriteLine("Username and password do not match.");
                    Console.WriteLine();
                    goto InvalidPass;
                }
            }
            catch(ArgumentNullException){
                Console.WriteLine("Enter a password to login.");
                Console.WriteLine();
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            }while(flag2 is true);

        /// <summary>
        /// Loop to provide user functions
/// - add reviews to a restaurant as a user
/// - search restaurant (by name, rating, zip code, etc.) 
/// 
/// TODO:
/// add review should get user id and add to review
/// </summary>
            bool flag3 = true;
            do
            {
                Console.WriteLine("Use individual restaurant search to see reviews. View all restaurants to get available options. ");
                Console.WriteLine("[0] Search for a restaurant by name");
                Console.WriteLine("[1] Search for a restaurant by zipcode");
                Console.WriteLine("[2] View all restaurants");
                Console.WriteLine("[3] Add a review for a restaurant");
                Console.WriteLine("[4] Logout");
                
                switch(Console.ReadLine())
                {
                    case "0":
                        RestaurantLookupNameUI();
                    break;
                        
                    case "1":
                        RestaurantLookupZipUI();
                    break;

                    case "2":
                        ViewAllRestaurants();
                    break;

                    case "3":
                        AddReviewUI();
                    break;

                    case "4":
                        Console.WriteLine($"Goodbye {userName}!");
                        flag3 = false;
                    break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                    break;
                }
            }while(flag3 is true);
        }
/// <summary>
/// View all functions for looking up restaurants, users, and reviews
/// </summary>
        private void ViewAllRestaurants()
        {
            List<Models.Restaurant> restaurants = _reviewbl.ViewAllRestaurants();
            
            foreach(Models.Restaurant restaurant in restaurants)
            {
            List<Reviews> reviewList = AvgReviewRatingsUI(restaurant.Id);
            double reviewNums = 0;
            int count = 0;
            foreach(Reviews review in reviewList)
            {
                reviewNums += review.Rating;
                count++;
            }
            double reviewAvg = reviewNums/count; 

                Console.WriteLine($@"
               -------------------------------------------
                Name: {restaurant.Name} 
                ZipCode: {restaurant.ZipCode}
                Average Rating: {reviewAvg:N2}
                -------------------------------------------
                ");
            }
        }

            private void ViewAllUsers()
        {
            List<Models.Users> users = _reviewbl.ViewAllUsers();
            foreach(Models.Users user in users)
            {
                int userId = CheckUserIdUI(user.Name);
                Console.WriteLine($@"
               -------------------------------------------
                Name: {user.Name} 
                Username: {user.UserName}
                ID: {userId}
                Password: {user.Password}
                -------------------------------------------
                ");
            }
        }
        
        private void ViewAllReviews()
        {
            List<Models.Reviews> reviews = _reviewbl.ViewAllReviews();
            foreach(Models.Reviews review in reviews)
            {
                string restName = RestaurantLookupIdUI(review.RestaurantId);
                Console.WriteLine($@"
                -------------------------------------------
                Rating: {review.Rating} 
                Review: {review.Content}
                Name: {restName}
                -------------------------------------------
                ");
            }
        }

/// <summary>
/// Calulate avg reviews for passed in restaurant
/// </summary>
        private List<Reviews> AvgReviewRatingsUI(int restaurantId)
        {
            List<Models.Reviews> reviews = _reviewbl.AvgReviewRatings(restaurantId);
            return reviews;
        }

/// <summary>
/// Restaurant Lookup by name and lookup by resaurant id via foreign key
/// Takes in a restaurant name and returns name and zipcode
/// </summary>
        private void RestaurantLookupNameUI()
        {
            string input;
            Console.WriteLine("Enter restaurant name to search");
            input = Console.ReadLine();

            Models.Restaurant foundRestaurant = _reviewbl.RestaurantLookupName(input);
            List<Reviews> reviewList = AvgReviewRatingsUI(foundRestaurant.Id);
            double reviewNums = 0;
            int count = 0;
            foreach(Reviews review in reviewList)
            {
                reviewNums += review.Rating;
                count++;
            }
            double reviewAvg = reviewNums/count; 

            if(foundRestaurant.Name is null){
                Console.WriteLine($"{input} was not found");
                Console.WriteLine();
            }
            else{
 
                Console.WriteLine($@"Restaurant found!
                -------------------------------------------
                Name: {foundRestaurant.Name} 
                Zipcode: {foundRestaurant.ZipCode}
                Average Reviews: {reviewAvg}
                -------------------------------------------3
                ");
                ReviewsForRestaurantUI(foundRestaurant.Id);     
            }

        }

        private string RestaurantLookupIdUI(int restaurantId)
        {
            Models.Restaurant foundRestaurant = _reviewbl.RestaurantLookupId(restaurantId);
            return foundRestaurant.Name;

        }

        private string UserLookupNameUI(int userId)
        {
            Models.Users foundUser = _reviewbl.UserLookupName(userId);
            return foundUser.UserName;

        }
/// <summary>
/// Restaurant lookup by zipcode
/// </summary>
                private void RestaurantLookupZipUI()
        {
            string zipcode;
            Console.WriteLine("Enter zipcode to search by");
            zipcode = Console.ReadLine();

            Models.Restaurant foundRestaurant = _reviewbl.RestaurantLookupZip(zipcode);
            List<Reviews> reviewList = AvgReviewRatingsUI(foundRestaurant.Id);
            double reviewNums = 0;
            int count = 0;
            foreach(Reviews review in reviewList)
            {
                reviewNums += review.Rating;
                count++;
            }
            double reviewAvg = reviewNums/count; 

            if(foundRestaurant.Name is null){
                Console.WriteLine($"Search by {zipcode} found no results.");
                Console.WriteLine();
            }
            else{
 
                Console.WriteLine($@"Restaurant found!
                -------------------------------------------
                Name: {foundRestaurant.Name} 
                Zipcode: {foundRestaurant.ZipCode}
                Average Reviews: {reviewAvg}
                -------------------------------------------3
                ");
                ReviewsForRestaurantUI(foundRestaurant.Id);     
            }

        }
/// <summary>
/// Reviews lookup function to go inside restaurant lookup function
/// </summary>
/// <param name="restaurantId"></param>
        private void ReviewsForRestaurantUI(int restaurantId)
        {
            List<Models.Reviews> foundReview = _reviewbl.SearchReviewsByRestaurantId(restaurantId);
            

            foreach(Models.Reviews review in foundReview)
            {
                // string userName = UserLookupNameUI(review.UserId);
                Console.WriteLine($@"Reviews found!
                -------------------------------------------
                Review: {review.Content} 
                Rating: {review.Rating}
                ReviewDate: {review.ReviewDate}
                -------------------------------------------
                ");
            }

            
        }
/// <summary>
/// Add review function. Calls RestaurantLookUpForReviewAddUI()
/// </summary>
         private void AddReviewUI() 
        {
            int rating = 0;
            string content;
            string restaurantName;
            Models.Reviews reviewToAdd;

            Console.WriteLine("Enter your review details: ");

            do{

            redoRating:
            Console.WriteLine("Rating (1-5): ");
            try{
            rating = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException)
            {
                Console.WriteLine("Error: Only include numbers from 1-5");
                Console.WriteLine();
                goto redoRating;
            }
            catch(OverflowException)
            {
                Console.WriteLine("Error: Only include numbers from 1-5");
                Console.WriteLine();
            }
            bool numRegex = Regex.IsMatch(Convert.ToString(rating), @"^[1-5]+$");
            if(numRegex is false){
                Console.WriteLine("Error: Enter a number from 1 to 5 ");
                Console.WriteLine();
                goto redoRating;
            }
            if(rating < 1 || rating > 5){
                Console.WriteLine("Rating is not within our scale. Use 1-5:");
                Console.WriteLine();
                goto redoRating;
            }
            Console.WriteLine("You entered: {0}", rating);
            Console.WriteLine();

            }while(String.IsNullOrWhiteSpace(Convert.ToString(rating)));

            do{

            Console.WriteLine("Review: ");
            content = Console.ReadLine();
            
            }while(String.IsNullOrWhiteSpace(content));
            Console.WriteLine(); //for spacing

            int restId = 0;
            do{
            Console.WriteLine();
            redoRestName:
            Console.WriteLine("Enter a restaurant name: ");
            restaurantName = Console.ReadLine();
            try{
                restId = RestaurantLookupForReviewAddUI(restaurantName);
            }
            catch(NullReferenceException){
                Console.WriteLine("Error: Restaurant not found: Check your spelling and try again.");
                goto redoRestName;
            }
            }while(String.IsNullOrWhiteSpace(restaurantName));

            reviewToAdd = new Reviews(rating, content, restId);
            reviewToAdd = _reviewbl.AddReview(reviewToAdd);

            Console.WriteLine($"Review was successfully added!");

        }
/// <summary>
/// Function to add a new user to the database
/// </summary>
/// <param name="userName"></param>
         private void AddUserUI() 
        {
            string name = "";
            string userName = "";
            string password = "";
            string verifyPass = "";
            Models.Users userToAdd;

        do{

            Console.WriteLine("Enter your name please: ");
            name = Console.ReadLine();

            /// <summary>
            /// Validate name not numbers
            /// </summary>

            bool nameRegex = Regex.IsMatch(name, @"^[a-zA-Z]+$");
            if (nameRegex == false)
            Console.WriteLine("Error: Name cannot contain numbers");

        }while(String.IsNullOrWhiteSpace(name));
        
        do{
            nameInUse:
            Console.WriteLine("Enter your desired username: ");
            userName = Console.ReadLine();
            bool checkNameAvailable = CheckUserNameUI(userName);
            if(checkNameAvailable is true){
                Console.WriteLine("That Username is already in use. Please choose another: ");
                goto nameInUse;
            }else if(checkNameAvailable is false){
                Console.WriteLine("Congratulations! That name is not in use!");
            }

        }while(String.IsNullOrWhiteSpace(userName));

        
        do{
            doAgainPass:
            Console.WriteLine("Enter your desired password: ");
            password = Console.ReadLine();
            Console.WriteLine("Please re-enter your password: ");
            verifyPass = Console.ReadLine();
            if(password == verifyPass){
            Console.WriteLine("You entered: ********");
            }else{
                Console.WriteLine("Passwords do not match!");
                goto doAgainPass;
            }
            

        }while(String.IsNullOrWhiteSpace(password));

            Console.WriteLine("Please confirm your information: ");
            Console.WriteLine($@"
            --------------------------------------------
                Namne: {name}
                Username: {userName}
                Password: *********
            --------------------------------------------
             ");
             Console.WriteLine("Is this correct (Y/N) ");
             string YorN = Console.ReadLine();
             if(YorN.ToLower().Equals("y")){
                userToAdd = new Models.Users(name, userName, password);
                userToAdd = _reviewbl.AddUser(userToAdd);
                Console.WriteLine("Information confirmed! Welcome!");
             }else if (YorN.ToLower().Equals("n")){
                Console.WriteLine("Information incorrect: Returning to main menu");
             }

            Console.WriteLine("Redirecting to main page.");
        }

/// <summary>
/// Function to get restaurant id for leaving a review
/// </summary>
/// <param name="name"></param>
/// <returns></returns>
            private int RestaurantLookupForReviewAddUI(string name)
           {

                Models.Restaurant foundRestaurant = _reviewbl.RestaurantLookupNameForReviewAdd(name);
                return foundRestaurant.Id;
            }    

            private string PassowrdVerifyUserUI(string userName)
            {
                Models.Users foundUser = _reviewbl.PasswordVerifyUser(userName);
                return foundUser.Password;
            }

            private string PassowrdVerifyAdminUI()
            {
                string foundAdmin = _reviewbl.PasswordVerifyAdmin();
                return foundAdmin;
            }

            private bool CheckUserNameUI(string userName){
                bool foundName = _reviewbl.CheckUserName(userName);
                return foundName;
            }

            private int CheckUserIdUI(string userName)
            {
                Models.Users foundUser = _reviewbl.CheckUserId(userName);
                return foundUser.Id;
            }

            private Models.Users CheckUserInfoUI(string userName)
            {
                Models.Users foundUser = _reviewbl.CheckUserId(userName);
                return foundUser;
            }


    }
}