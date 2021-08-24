using System;

namespace RightStakes.Challenge.Domain.Entities
{
    public class Quote : Entity
    {
        public string Name { get; private set; }

        public decimal Value { get; private set; }

        public DateTime LastUpdate { get; set; }

        protected Quote() { }

        public Quote(string name, decimal value)
        {
            Name = name;
            Value = value;
            LastUpdate = DateTime.Now;
        }

        public void Update(decimal value)
        {
            Value = value;
            LastUpdate = DateTime.Now;
        }
    }
}
