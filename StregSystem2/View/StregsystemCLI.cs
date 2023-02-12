using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StregSystem2.Interfaces;
using StregSystem2.Model;

namespace StregSystem2.View
{
    public delegate void StregsystemEvent(string command);

    public class StregsystemCLI : IStregsystemUI
    {
        private readonly IStregsystem _stregsystem;
        public event StregsystemEvent CommandEntered;


        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }


        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User [{0}] not found!", username);
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine("Product [{0}] not found!", product);
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine("Username: {0}", user.UserName);
            Console.WriteLine("Balance: {0}", user.Balance);
            Console.WriteLine("Activated: {0}", user.active ? "Yes" : "No");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("Too many arguments for command: {0}", command);
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine("Admin command [{0}] not found!", adminCommand);
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("{0} bought {1} for {2}", transaction.User.UserName, transaction.Product.Name,
                transaction.Amount);
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("{0} bought {1} x {2} for {3}", transaction.User.UserName, count,
                transaction.Product.Name, transaction.Amount);
        }

        public void Close()
        {
            Console.WriteLine("Closing Stregsystem CLI...");
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("{0} has insufficient funds to buy {1}", user.UserName, product.Name);
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error: {0}", errorString);
        }

        public void Start()
        {
            Console.WriteLine("Loading users and products data...");
            _stregsystem.LoadUserData("userdata.csv");
            _stregsystem.LoadProductData("productdata.csv");
            Console.WriteLine("Data loaded successfully.");
            var users = _stregsystem.GetUsers(u => u.Balance >= 0);

            foreach (var u in users)
            {
                Console.WriteLine("{0} - {1} - {2}", u.Id, u.UserName, u.FirstName);
                
            }
            
            Console.WriteLine("Please enter your username: ");
            var username = Console.ReadLine();
            var user = _stregsystem.GetUserByUserName(username);
            while (user == null)
            {
                DisplayUserNotFound(username);
                username = Console.ReadLine();
                user = _stregsystem.GetUserByUserName(username);
            }
           
           

           

            DisplayUserInfo(user);
          
            while (true)
            {
                Console.WriteLine("Stregsystem CLI started!");
                Console.WriteLine("Available products:");

                var activeProducts = _stregsystem.ActiveProducts.Where(p => p.Active);
                foreach (var products in activeProducts)
                {
                    Console.WriteLine("{0} - {1} - {2}", products.Id, products.Name, products.Price);
                }

                Console.WriteLine("Enter the product id you want to buy or type 'quit' to exit: ");
                var input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                int productId;
                if (!int.TryParse(input, out productId))
                {
                    DisplayGeneralError("Invalid product id.");
                    continue;
                }

                var product = _stregsystem.GetProductById(productId);
                if (product == null)
                {
                    DisplayProductNotFound(input);
                    continue;
                }

                if (!product.Active)
                {
                    Console.WriteLine("Product is inactive.");
                    continue;
                }

                var buyTransaction = _stregsystem.BuyProduct(user, product);
                if (buyTransaction == null)
                {
                    DisplayInsufficientCash(user, product);
                    continue;
                }

                DisplayUserBuysProduct(buyTransaction);
            }

            Console.WriteLine("Thank you for using Quickbuy System. Have a great day!");
            Close();
        }
    }
}