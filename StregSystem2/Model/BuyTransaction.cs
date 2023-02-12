using System;
using StregSystem2.Exceptions;

namespace StregSystem2.Model
{
    public class BuyTransaction:Transaction
    {
        public BuyTransaction(User user, decimal amount, Product product) : base(
            user,  amount)
        {
             Product = product;
        }

        public Product Product { get; set; }

        public override string ToString()
       {
           return $"{base.ToString()} | Type: Buy | Product: {Product}";
       }

       
        public override void Execute()
        { 
            if (User.Balance > Amount)
            {
               Success = true;
                User.Balance -= Amount;
            }
            else
            {
                Success = false;
                throw new InsufficientCreditsException(User, Product, "User does not have enough credits to purchase the product.");

            }
           

        }
    }
    }
