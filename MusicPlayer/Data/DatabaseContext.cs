using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MusicPlayer.Data
{
    public class DatabaseContext : DbContext
    {
        private string connectionstring = "";

        public DbSet <User> Credentials { get; set; }
        public DbSet<UserPreferences> Preferences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
            
        }
       
    }
}
