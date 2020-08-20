using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork _unitOfWork;

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            return Ok(_unitOfWork.Patients.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult<Patient> GetById(int id)
        {
            try
            {
                return Ok(_unitOfWork.Patients.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<Patient> Add(Patient patient)
        {
            try
            {
                Patient newPatient =_unitOfWork.Patients.Add(patient);
                _unitOfWork.SaveChanges();
                return Ok(newPatient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<Patient> Edit(Patient patient)
        {
            try
            {
                Patient newPatient = _unitOfWork.Patients.Update(patient);
                _unitOfWork.SaveChanges();
                return Ok(newPatient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult RemoveById(int id)
        {
            try
            {
                _unitOfWork.Patients.RemoveById(id);
                _unitOfWork.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
