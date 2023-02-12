using System;
using System.Collections.Generic;
using StregSystem2.Model;

namespace StregSystem2.Interfaces
{
    public interface IStregsystem
    { 
        List<Product> ActiveProducts { get; }
        event EventHandler<UserBalanceNotification> UserBalanceWarning;

        void LoadProductData(string fileName);
        void LoadUserData(string fileName); 
        BuyTransaction BuyProduct(User user, Product product);
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        void ExecuteTransaction(Transaction transaction);
        Product GetProductById(int productId);
        List<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUserName(string username);
        List<Transaction> GetTransactions(User user, int count);
    }
}