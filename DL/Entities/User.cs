using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Admins = new HashSet<Admin>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
