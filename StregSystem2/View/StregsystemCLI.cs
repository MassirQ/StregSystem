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

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }

        public event StregsystemEvent CommandEntered;

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
            _stregsystem.LoadProductData("products.csv");
            _stregsystem.LoadUserData("users.csv");
            Console.WriteLine("Stregsystem CLI started!");
            Console.WriteLine("Available products:");

            var users = _stregsystem.GetUsers(u => u.Balance >= 0);

            foreach (var user in users)
            {
                Console.WriteLine("{0} - {1} - {2}", user.Id, user.UserName, user.FirstName);
                
            }
            
            var activeProducts = _stregsystem.ActiveProducts.Where(p => p.Active);
            foreach (var product in activeProducts)
            {
                Console.WriteLine("{0} - {1} - {2}", product.Id, product.Name, product.Price);
            }
            Console.WriteLine(
                "Enter quickbuy command (e.g. 'quickbuy 1 2') to buy a product, or 'exit' to exit the program.");
            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                
                if (command.ToLower() == "exit")
                {
                    break;
                }

                if (command.ToLower() == "1")
                {

                }
                
                if (command.ToLower() == "2")
                {
                }

                var args = command.Split(' ');
            }

        }
    }
}