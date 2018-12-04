using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Models
{
    public static class ProtectedArticles
    {
        public static string[] ToArray()
        {
            return new[]
            {
                HomePage
            };
        }

        public const string HomePage = "home-page";
    }
}
