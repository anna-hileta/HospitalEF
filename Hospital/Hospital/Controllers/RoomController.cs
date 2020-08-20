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
    public class RoomController : ControllerBase
    {

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork _unitOfWork;

        [HttpGet]
        public ActionResult<IEnumerable<Room>> Get()
        {
            return Ok(_unitOfWork.Rooms.GetAll().ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<Room> GetById([FromRoute]int id)
        {
            try
            {
                return Ok(_unitOfWork.Rooms.GetById(id));
            }
            catch (Exception)
            {
                return NotFound("Not Found");
            }
        }
        [HttpPost]
        public ActionResult<Room> Add([FromBody] Room room)
        {
            try
            {
                Room newRoom = _unitOfWork.Rooms.Add(room);
                _unitOfWork.SaveChanges();
                return Ok(newRoom);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<Room> Edit([FromBody]Room room)
        {
            try
            {
                Room newRoom = _unitOfWork.Rooms.Update(room);
                _unitOfWork.SaveChanges();
                return Ok(newRoom);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult RemoveById([FromRoute]int id)
        {
            try
            {
                _unitOfWork.Rooms.RemoveById(id);
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
