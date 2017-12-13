using DijitalPazarlama.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijitalPazarlama.Data
{
    class SaveData
    {
        public static void SaveUser(string name, string lastname, string username, string password)
        {
            using (StreamWriter writer = new StreamWriter("users.txt", true))
            {
                int id;
                id = Database.Users.Count + 1;
                AppUser user = new AppUser();
                user.Id = id;
                user.Name = name;
                user.Lastname = lastname;
                user.Username = username;
                user.Password = password;
                user.Role = Role.User;

                Database.Users.Add(user);

                string yenisatir = "\r\n";
                if (id == 1)
                    yenisatir = "";

                string writable = $"{yenisatir}Id@{id};Name@{name};Lastname@{lastname};Username@{username};Password@{password};Role@User";
                writer.Write(writable);
            }
        }
        public static void SaveCategory(string name, string description)
        {
            using (StreamWriter writer = new StreamWriter("categories.txt", true))
            {
                int id;
                id = Database.Categories.Count + 1;
                Category category = new Category();
                category.Id = id;
                category.Name = name;
                category.Description = description;

                Database.Categories.Add(category);

                string yenisatir = "\r\n";
                if (id == 1)
                    yenisatir = "";

                string writable = $"{yenisatir}Id@{id};Name@{name};Description@{description}";
                writer.Write(writable);
            }
        }
        public static void SaveProduct(string name, string description, int categoryid, decimal price, string picturename, string picturepath)
        {
            using (StreamWriter writer = new StreamWriter("products.txt", true))
            {
                int id;
                id = Database.Products.Count + 1;
                Product product = new Product();
                product.Id = id;
                product.CategoryId = categoryid;
                product.Name = name;
                product.Description = description;
                product.price = price;
                product.PictureName = picturename;

                Database.Products.Add(product);

                string yenisatir = "\r\n";
                if (id == 1)
                    yenisatir = "";

                //resim kopyalama
                if (picturename != picturepath)
                {
                    File.Copy(picturepath, @"img\" + picturename);
                }
                //

                string writable = $"{yenisatir}Id@{id};CategoryId@{categoryid};Name@{name};Description@{description};Price@{price};PicturePath@{picturename}";
                writer.Write(writable);
            }
        }
    }
}
