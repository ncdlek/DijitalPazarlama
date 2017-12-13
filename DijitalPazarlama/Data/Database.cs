using DijitalPazarlama.Model;
using System.Collections.Generic;

namespace DijitalPazarlama.Data
{
    public static class Database
    {
        static Database()
        {
            Users = new List<AppUser>();
            Categories = new List<Category>();
            Products = new List<Product>();
        }
        public static List<AppUser> Users { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Product> Products { get; set; }
    }
}
