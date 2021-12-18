using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly AddressAppService _AddressAppService;



        public AddressController(AddressAppService addressAppService)
        {
            _AddressAppService = addressAppService;

        }
        // GET: api/<AddressController>
        [HttpGet]
        public IActionResult Get()
        {
            var Addresss = _AddressAppService.GetAllAddresses();
            if (Addresss.Count == 0)
            {
                return NotFound();
            }
            return Ok(Addresss);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Addresses = _AddressAppService.GetAddressesByPersonId(id);
            if (Addresses == null)
            {
                return NotFound();
            }
            return Ok(Addresses);
        }



 
    }
}
