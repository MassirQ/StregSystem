using System;

namespace StregSystem2.Model
{
    public class Product
    {
        private int _id;
        private string _name;
        private decimal _price;
        private bool _active;
        private bool _canBeBoughtOnCredit;


        public Product(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be greater than or equal to 1.");
            }
            if (name == null || name.Trim().Length < 1)
            {
                throw new ArgumentException("Name must not be null or empty.");
            }
            _id = id;
            _name = name;
            _price = price;
            _active = active;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Price: {_price}";
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public bool Active
        {
            get => _active;
            set => _active = value;
        }

        public bool CanBeBoughtOnCredit
        {
            get => _canBeBoughtOnCredit;
            set => _canBeBoughtOnCredit = value;
        }
    }
}