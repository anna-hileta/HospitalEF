using Core.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IRoomRepository Rooms { get; }
        void SaveChanges();
    }
}
