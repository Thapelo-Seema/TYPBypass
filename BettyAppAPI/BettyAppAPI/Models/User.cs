using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Models
{
    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        [Key]
        public string id { get; set; }
        public string email { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public string password { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        //public Date dob { get; set; }
        public string nationality { get; set; }
        public string contact_no { get; set; }
        public string residentialAddress { get; set; }
    }
}
