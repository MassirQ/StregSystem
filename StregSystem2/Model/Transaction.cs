using System;

namespace StregSystem2.Model
{
    public abstract class Transaction
    {
        private int _id;
        private DateTime _date;
        private decimal _amount;


        protected Transaction( User user, decimal amount)
      {
          this._id = DateTime.Now.Millisecond;
            User = user;
            this._date = DateTime.Now;
            _amount = amount;
        }

        public bool Success { get; set; }

        public int Id
       {
           get => _id;
           set => _id = value;
       }

        public User User { get; }

       public DateTime Date
       {
           get => _date;
           set => _date = value;
       }

       public decimal Amount
       {
           get => _amount;
           set => _amount = value;
       }



       public abstract void Execute();
       public override string ToString()
        {
            return $"Transaction ID: {_id}, User: {User.UserName}, Date: {_date.ToString("dd/mm/yyyy HH:mm:ss")}, Amount: {_amount}";
        }
       
       

    }
    
    

}