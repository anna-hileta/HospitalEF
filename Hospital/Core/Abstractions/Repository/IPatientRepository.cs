using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions.Repository
{
    public interface IPatientRepository: IRepository<Patient, int>
    {
    }
}
