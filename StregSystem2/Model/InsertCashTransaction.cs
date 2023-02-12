using System;
using StregSystem2.Exceptions;

namespace StregSystem2.Model
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {
            
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Type: Insert Cash";
        }
        public override void Execute()
        {
            if (Amount > 0)
            {
                User.Balance += Amount;
                Success = true;
            }
            else
            {
                Console.WriteLine("Your amount have to be more than 0");
            }
           
            
        }
        

        
    }
}

