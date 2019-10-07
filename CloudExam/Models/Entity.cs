using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Models
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
    public abstract class Entity : Entity<int>
    {
    }
}

