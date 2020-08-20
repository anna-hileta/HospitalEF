using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
