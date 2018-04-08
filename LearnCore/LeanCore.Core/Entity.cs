using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCore.Core
{
    public abstract class Entity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
    public abstract class Entity : Entity<int> {

    }
}
