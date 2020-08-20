using Core.Abstractions.Repository;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class PatientRepository: BaseRepository<Patient, int>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }
    }
}
