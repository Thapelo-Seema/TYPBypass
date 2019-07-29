using BettyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Dtos
{
    public class UserDto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        //public Date dob { get; set; }
        public string nationality { get; set; }
        public string contact_no { get; set; }
        public string password { get; set; }
        public string residentialAddress { get; set; }
    }
}
