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
        private string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet <User> Credentials { get; set; }
        public DbSet<UserPreferences> Preferences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
            
        }
       
    }
}
