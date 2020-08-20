using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Patient : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
