using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? UserId { get; set; }
        public int? RestaurantId { get; set; }
        public int Rating { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
    }
}
