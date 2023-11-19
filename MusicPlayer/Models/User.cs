using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    [PrimaryKey(nameof(ID))]
    public class User
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string iD, string userName, string password, string email)
        {
            ID = iD;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
