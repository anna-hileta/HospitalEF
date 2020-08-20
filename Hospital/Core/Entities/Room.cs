using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Room : IEntity<int>
    {
        public int Id { get; set; }
        public List<Patient> Patients { get; set; }
        public int RoomNumber { get; set; }
    }
}
