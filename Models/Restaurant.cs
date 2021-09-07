using System.Collections.Generic;
using System.Dynamic;

namespace Models
{
    public class Restaurant
    {
        public Restaurant(){}
        public Restaurant(string name)
        {
            this.Name = name;
        }

        public Restaurant(string name, string zipcode, string street, string cuisine) : this(name)
        {
            this.ZipCode = zipcode;
            this.Street = street;
            this.Cuisine = cuisine;
        }
        public Restaurant(int id, string name, string zipcode, string street, string cuisine) : this(name)
        {
            this.Id = id;
            this.ZipCode = zipcode;
            this.Street = street;
            this.Cuisine = cuisine;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Cuisine { get; set; }

        List<Models.Reviews> reviewList { get; set; }

    }
}