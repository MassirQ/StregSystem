using System;
using StregSystem2.Model;

namespace StregSystem2.Exceptions
{
    public class InsufficientCreditsException:Exception
    {
        private User _user;
        private Product _product;
        
        public InsufficientCreditsException(User user, Product product, string message)
            : base(message)
        {
            _user = user;
            _product = product;
        }
        
    }
}