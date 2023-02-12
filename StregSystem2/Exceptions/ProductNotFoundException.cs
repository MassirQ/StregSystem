using System;

namespace StregSystem2.Exceptions
{
    public class ProductNotFoundException : Exception

    {
        public int ProductId { get; }

    public ProductNotFoundException(int productID) : base("Product with ID " + productID + " was not found.")
    {
        ProductId = productID;
    }
    }
}