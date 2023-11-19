using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Resources
{
    public static class Utilities
    {
        private const int random_string_length = 7;
        public static string GenerateUserId() => RandomString();

        private static string RandomString()
        {
            var str_build = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < random_string_length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                char letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
