using System;

namespace StregSystem2.Model
{
    public class SeasonalProduct:Product
    {
        private DateTime _seasonStartDate;
        private DateTime _seasonEndDate;
        public SeasonalProduct(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit, DateTime seasonStartDate, DateTime seasonEndDate) : base(id,
            name, price, active, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = seasonEndDate;
        }

        public DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            set => _seasonStartDate = value;
        }

        public DateTime SeasonEndDate
        {
            get => _seasonEndDate;
            set => _seasonEndDate = value;
        }

        public override string ToString()
        {
            return base.ToString() + $" Season Start: {_seasonStartDate} Season End: {_seasonEndDate}";
        }
    }
}