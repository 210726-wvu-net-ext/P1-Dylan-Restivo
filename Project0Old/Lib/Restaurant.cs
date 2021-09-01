namespace Lib
{
    /// <summary>
    /// Make list of reastaurants
    /// restauratns need rating, name, other search params
    /// function to calculate reviews for each restaurant
    /// </summary>
    public class Restaurant
    {
        public Restaurant(string name, string zipcode){
            this.Name = name;
            this.Zipcode = zipcode;
        }
        private int rating;
        public int Rating { get; set; }
        private string name;
        public string Name { get; set; }
        private string zipcode;
        public string Zipcode { get; set; }
    }
}