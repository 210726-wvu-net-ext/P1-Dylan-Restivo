using System;

namespace Models
{
    public class Users
    {
        public Users(){}
        public Users(string name)
        {
            this.Name = name;
        }
        public Users(string name, string username, string password) : this(name)
        {
            this.UserName = username;
            this.Password = password;
        }
        public Users(string name, string username, string password, int id) : this(name)
        {   
            this.UserName = username;
            this.Password = password;
            this.Id = id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
