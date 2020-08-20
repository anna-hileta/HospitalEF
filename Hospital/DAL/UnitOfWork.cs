using Core.Abstractions;
using Core.Abstractions.Repository;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }
        private IPatientRepository _patients;
        public IPatientRepository Patients 
        { 
            get
            {
                return _patients ??= new PatientRepository(_context);
            }
        }
        private IRoomRepository _rooms;
        public IRoomRepository Rooms => _rooms ??= new RoomRepository(_context);

        private HospitalContext _context;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
