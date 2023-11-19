using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    [PrimaryKey(nameof(ID))]
    public class UserPreferences
    {
        public string ID { get; set; }

        public int DefaultVolume { get; set; }
        
        //preferred genres
        //profile picture etc

        

    }
}
