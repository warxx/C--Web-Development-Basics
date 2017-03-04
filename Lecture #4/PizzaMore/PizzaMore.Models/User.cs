﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Models
{
    public class User
    {
        public User()
        {
            this.Suggestions = new HashSet<Pizza>();
        }

        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }

        public ICollection<Pizza> Suggestions { get; set; }
    }
}
