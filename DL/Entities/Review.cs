﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? ReviewDate { get; set; }
         
        public int UserId { get; set; }
   
        public int RestaurantId { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Id")]
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}