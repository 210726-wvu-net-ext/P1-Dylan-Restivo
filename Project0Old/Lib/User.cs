using System;
using System.Collections.Generic;
/// <summary>
/// - add a new user
/// - add reviews to a restaurant as a user 
/// - view details of restaurants as a user
/// - view reviews of restaurants as a user
/// </summary>
namespace Lib
{
    public class User
    {
        // create a user object
        // function for user to lookup their reviews
        // user should have an int id, string name
        public User(string name)
        {
            this.Name = name;
            this.Id = id;
        }
        private int id = 11111;
        public int Id { get; set; }
        private string name;
        public string Name { get; set; }
        private string username;
        public string UserName { get; set; }

        public void PrintUser(){
            Console.WriteLine($"This user is {this.Id} and user id is {this.Name}");
        }
        //Write review function write result to file
        public void WriteReview(){


        }
        public static User CreateUser(string name, string userName){
            User  Id = new User();
            users.Add(name);
            Id++;
        }

    }
}