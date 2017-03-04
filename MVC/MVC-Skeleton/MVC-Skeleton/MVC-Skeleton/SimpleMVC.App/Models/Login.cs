using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Models
{
    public class Login
    {
        [Key]
        public string SessionId { get; set; }

        public User User { get; set; }

        public bool IsActive { get; set; }
    }
}
