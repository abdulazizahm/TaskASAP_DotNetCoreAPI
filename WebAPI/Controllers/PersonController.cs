using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonAppService _PersonAppService;
        public PersonController(PersonAppService personAppService)
        {
            _PersonAppService = personAppService;

        }
        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get()
        {
            var Persons = _PersonAppService.GetAllPersons();
            if (Persons.Count == 0) 
            {
                return NotFound();
            }
            return Ok(Persons);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int ID)
        {
            var Person = _PersonAppService.GetById(ID);
            if (Person == null) 
            {
                return NotFound();
            }
            return Ok(Person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post(PersonViewModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (_PersonAppService.CheckPersonExists(person)) 
                {
                    return BadRequest("you already have an account on the system");
                }
                else 
                {
                    _PersonAppService.SaveNewPerson(person);
                    return CreatedAtAction(nameof(GetById), new { id = _PersonAppService.GetlastInsertedPersonId() }, _PersonAppService.GetlastInsertedPerson());
                }
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (_PersonAppService.UpdatePersonMyModel(Person, id)) 
                {
                    return CreatedAtAction(nameof(Get), new { id = Person.ID }, Person);
                }
                else 
                {
                    return NotFound();
                }
                
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Person = _PersonAppService.GetById(id);
            if (Person == null)
            {
                return NotFound();
            }
            try
            {
                _PersonAppService.DeletePerson(Person.ID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
