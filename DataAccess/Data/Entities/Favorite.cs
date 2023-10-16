﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
