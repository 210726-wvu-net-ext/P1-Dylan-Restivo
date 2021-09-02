using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Entities
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
