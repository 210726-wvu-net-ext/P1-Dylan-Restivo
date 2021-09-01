using System;
using System.Collections.Generic;
using Lib;


/// <summary>
/// - add a new user 
/// - ability to search user as admin
/// - display details of a restaurant for user
/// - add reviews to a restaurant as a user
/// - view details of restaurants as a user
/// - view reviews of restaurants as a user
/// - calculate reviews’ average rating for each restaurant
/// - search restaurant (by name, rating, zip code, etc.) 
/// </summary>
namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartUpFunc();
        }

        public static void StartUpFunc(){
            List<User> users = new List<User>();
            // List<Restaurant> restaurants = new List<Restaurant>();
            // List<Review> reviews = new List<Review>();
            Console.WriteLine("Welcome to EateryEvals!");
            Console.WriteLine("If you are a user please enter \"user\".\nIf you are an admin please enter \"admin\".");
            string response = Console.ReadLine();
            if (response.ToLower() == "user"){ // login as current user or sign up as new user
                Console.WriteLine("If you have an account with EateryEvals please enter your username, otherwise enter \"create\": ");
                string accountYOrN = Console.Read();
                    if (accountYOrN.toLower() = "create"){
                        // Users.CreateUser();
                    }else if (accountYOrN.To == 'n'){
                        Console.WriteLine
                    }else Console.WriteLine("Please enter a username or the word \"create\" with no qoutes.")
                Console.WriteLine("");
            }else if (response.ToLower() == "admin"){ // login as admin if you have password
                int loginAttempts = 4;
                attemptsAbv0: // label to return to if admin pass attempts > 0
                Console.WriteLine("Please enter password to login as admin: ");
                string password = Console.ReadLine();
                if (password == "admin"){
                    Console.WriteLine("Welcome admin!");
                    /*
                    Add functionality to search user
                    */
                }else{
                    // Counts down attempts to login and exits program if too many attmepts fail
                    // else goes back up to asking for password
                    loginAttempts--;
                    Console.WriteLine($"Incorrect password. You have {loginAttempts} ramining.");
                    if(loginAttempts == 0) Environment.Exit(0);
                }
                goto attemptsAbv0;
            }
        }
    }
}