using System.Collections.Generic;
namespace Models
{
    public class Restaurant
    {
        public Restaurant(){}
        public Restaurant(string name)
        {
            this.Name = name;
        }

        public Restaurant(int id,string name, string zipcode) : this(name)
        {
            this.Id = id;
            this.ZipCode = zipcode;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public List<Reviews> Reviews { get; set; }
    }
}