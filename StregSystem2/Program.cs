using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using StregSystem2.Interfaces;
using StregSystem2.Model;
using StregSystem2.View;

namespace StregSystem2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IStregsystem stregSystem = new StregSystem();
            StregsystemCLI cli = new StregsystemCLI(stregSystem);
            cli.Start();
            //StregSystem stregSystem = new StregSystem();
            //User user2 = new User(1, "Massir", "Qauomi", "massir5", "google@domain.dk", 30);
            //User user1 = new User(1, "Massir", "Qauomi", "massir6", "google@domain.dk", 30);
            //Product product3 = new Product(31, "Redbull",5 ,true, false);
            //Product product2 = new Product(1, "Redbull",5 ,true, false);
            //stregSystem.Products.Add(product2);
            //stregSystem.Users.Add(user2);
            //stregSystem.Users.Add(user1);
            
           
            
            //Console.WriteLine(user2.Balance);

           
            
            //Product product = stregSystem.GetProductById(1);
            //List <User> Users = stregSystem.GetUsers(u => u.Balance >= 0);
            //List<Product> products = stregSystem.ActiveProducts;
            //User user = stregSystem.GetUserByUserName("massir5");
            //Console.WriteLine("Massir har" + " " + user.Balance);
            //BuyTransaction transaction = stregSystem.BuyProduct(user, product);
            //Console.WriteLine("Massir Køber en redbull for 50kr og har tilbage " + " " + user.Balance);
            //BuyTransaction transaction2 = stregSystem.BuyProduct(user1, product2);
            //Console.WriteLine(stregSystem.Transactions.Count);
            //InsertCashTransaction transaction3 = stregSystem.AddCreditsToAccount(user2, 500);
            //List<Transaction> Transactions = stregSystem.GetTransactions(user, 10);
            //Console.WriteLine("Massir indsætter 500kr og har nu " + " " + user.Balance);
            //Console.WriteLine(stregSystem.Transactions.Count);
            //Console.WriteLine(product);
            //Console.WriteLine(user.FirstName);
           // Console.WriteLine(Transactions.Count);
            //Console.WriteLine(products.Count);
            //stregSystem.LoadProductData("products.csv");
            //List<Product> products = stregSystem.Products;
            //Console.WriteLine(products.Count);

            //stregSystem.LoadUserData("users.csv");
            //List<User> users = stregSystem.Users;
            //Console.WriteLine(users.Count);
            //Console.WriteLine(products);






        }
    }
}