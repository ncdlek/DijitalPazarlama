using DijitalPazarlama.Model;
using System;
using System.IO;

namespace DijitalPazarlama.Data
{
    public static class LoadData
    {
        public static void LoadUsers()
        {
            using (StreamReader reader = new StreamReader("users.txt"))
            {
                string currentLine = "";

                while (!reader.EndOfStream)
                {
                    AppUser u = new AppUser();

                    currentLine = reader.ReadLine();
                    u.Id = int.Parse(currentLine.Split(';')[0].Split('@')[1]);
                    u.Name = currentLine.Split(';')[1].Split('@')[1];
                    u.Lastname = currentLine.Split(';')[2].Split('@')[1];
                    u.Username = currentLine.Split(';')[3].Split('@')[1];
                    u.Password = currentLine.Split(';')[4].Split('@')[1];
                    u.Role = (Role)Enum.Parse(typeof(Role), currentLine.Split(';')[5].Split('@')[1]);

                    Database.Users.Add(u);
                }
            }
        }
        public static void LoadCategories()
        {
            using (StreamReader reader = new StreamReader("categories.txt"))
            {
                string currentLine = "";

                while (!reader.EndOfStream)
                {
                    Category u = new Category();

                    currentLine = reader.ReadLine();
                    u.Id = int.Parse(currentLine.Split(';')[0].Split('@')[1]);
                    u.Name = currentLine.Split(';')[1].Split('@')[1];
                    u.Description = currentLine.Split(';')[2].Split('@')[1];

                    Database.Categories.Add(u);
                }
            }
        }
        public static void LoadProducts()
        {
            using (StreamReader reader = new StreamReader("products.txt"))
            {
                string currentLine = "";

                while (!reader.EndOfStream)
                {
                    Product u = new Product();

                    currentLine = reader.ReadLine();
                    u.Id = int.Parse(currentLine.Split(';')[0].Split('@')[1]);
                    u.CategoryId = int.Parse(currentLine.Split(';')[1].Split('@')[1]);
                    u.Name = currentLine.Split(';')[2].Split('@')[1];
                    u.Description = currentLine.Split(';')[3].Split('@')[1];
                    u.price = decimal.Parse(currentLine.Split(';')[4].Split('@')[1]);
                    u.PictureName = currentLine.Split(';')[5].Split('@')[1];

                    Database.Products.Add(u);
                }
            }
        }
    }
}
