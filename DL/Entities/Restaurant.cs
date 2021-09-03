using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public string Cuisine { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
