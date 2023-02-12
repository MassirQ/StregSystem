using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using StregSystem2.Exceptions;
using StregSystem2.Interfaces;

namespace StregSystem2.Model
{
    
    public class StregSystem : IStregsystem
    {
        private List<User> _users;
        private List<Product> _products;
        private List<Transaction> _transactions;

        public List<Product> ActiveProducts
        {
            get { return _products.Where(p => p.Active).ToList(); }
        }


        public event EventHandler<UserBalanceNotification> UserBalanceWarning;

        public StregSystem()
        {
            _users = new List<User>();
            _products = new List<Product>();
            _transactions = new List<Transaction>();
        }

        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public List<Product> Products
        {
            get => _products;
            set => _products = value;
        }

        public List<Transaction> Transactions
        {
            get => _transactions;
            set => _transactions = value;
        }
        
        public void LoadProductData(string fileName)
        {
            using (StreamReader reader = new StreamReader(@"../../products.csv"))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                { 
                    string[] values = line.Split(';');
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = Regex.Replace(values[i], "<.*?>", string.Empty);
                        if (values[i].StartsWith("\"") && values[i].EndsWith("\""))
                        {
                            values[i] = values[i].Trim('"');
                        }
                    }

                   
                    int id = int.Parse(values[0]);
                    string Name = (values[1]);
                    decimal Price = decimal.Parse(values[2]);
                    bool active = values[3].Equals("1");
                    bool CanBeBoughtOnCredit = true;
                     Product product = new Product(id, Name, Price, active, CanBeBoughtOnCredit);

                    Products.Add(product);
                }
            }
        }
        
        public void LoadUserData(string fileName)
        {
          
                using (StreamReader reader = new StreamReader(@"../../users.csv"))
                {


                    string line = reader.ReadLine();
                   // Console.WriteLine("Header: " + line);
                    while ((line = reader.ReadLine()) != null)
                       // Console.WriteLine("Line: " + line);

                    {

                        string[] values = line.Split(',');
                        for (int i = 0; i < values.Length; i++)
                        {
                            values[i] = Regex.Replace(values[i], "<.*?>", string.Empty);
                            if (values[i].StartsWith("\"") && values[i].EndsWith("\""))
                            {
                                Console.WriteLine("Value " + (i + 1) + ": " + values[i]);

                                values[i] = values[i].Trim('"');

                            }
                            
                        }
                        int id = int.Parse(values[0]);
                        string FirstName = values[1];
                        string LastName = values[2];
                        string UserName = values[3];
                        decimal balance = decimal.Parse(values[4]);
                        string email = values[5];
                        User user = new User(id, FirstName, LastName, UserName, email, balance);
                        Users.Add(user);
                    }
                }
            
            
        }
        
        
        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product.Price, product);
            ExecuteTransaction(transaction);
            if (user.Balance < 50)
            {
               // UserBalanceWarning?.Invoke(user,user.Balance);
            }
            
            return transaction;
        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(transaction);
            return transaction;
        }


        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            if (transaction.Success)
            {
                _transactions.Add(transaction);
                //Path er altid i bin/debug
                using (var writer = new StreamWriter(@"../../transactions.txt", true))
                {
                    writer.WriteLine(transaction.ToString());
                }
                
            }
            else
            {
                Console.WriteLine("something is wrong");
            }
        }

        public Product GetProductById(int productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }

            return product;
        }

        public List<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate).ToList();
        }

        public User GetUserByUserName(string username)
        {
            var user = _users.SingleOrDefault(u => u.UserName == username);
            if (user == null)
            {
                Console.WriteLine("Please control your username");
            }

            return user;
        }
        
        public List<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.Where(t => Equals(t.User, user))
                .OrderByDescending(t => t.Date)
                .Take(count)
                .ToList();
        }
        
       
        
    }


    }


           
        

        
    
