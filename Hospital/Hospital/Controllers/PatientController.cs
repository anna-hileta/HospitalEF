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
        [HttpGet("{id}")]
        public ActionResult<Patient> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_unitOfWork.Patients.GetById(id));
            }
            catch (Exception)
            {
                return NotFound("Not Found");
            }
        }
        [HttpPost]
        public ActionResult<Patient> Add([FromBody] Patient patient)
        {
            try
            {
                Patient newPatient = _unitOfWork.Patients.Add(patient);
                _unitOfWork.SaveChanges();
                return Ok(newPatient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<Patient> Edit([FromBody] Patient patient)
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
        [HttpDelete("{id}")]
        public ActionResult RemoveById([FromRoute] int id)
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
