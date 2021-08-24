using System;

namespace RightStakes.Challenge.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Uid { get; private set; }

        public DateTime CreationDate { get; private set; }

        public Entity()
        {
            Uid = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
