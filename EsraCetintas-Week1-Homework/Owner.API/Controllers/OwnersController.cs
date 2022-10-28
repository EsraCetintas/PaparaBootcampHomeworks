﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;
using Owner.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        List<Model.Owner> _result;

        public OwnersController(OwnerData ownerData)
        {
            _result = ownerData.GetOwners();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Add(Model.Owner owner)
        {
            if(owner.Description.ToLower().IndexOf("hack") == -1)
            {
                _result.Add(owner);
                return Ok(_result);
            }

            return BadRequest("Attention! There is hack word in description");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var owner = _result.FirstOrDefault(p => p.Id == id);

            if(owner != null)
            {
                _result.Remove(owner);
                return Ok(_result);
            }

            return NotFound();
        }

        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Update(Model.Owner owner)
        {
            var ownerUpdated = _result.SingleOrDefault(p=> p.Id == owner.Id);
            
            if(ownerUpdated == null)
            {
                return BadRequest("Not found");
            }
           else  if (owner.Description.ToLower().IndexOf("hack") == -1)
            {
                ownerUpdated.Name = owner.Name;
                ownerUpdated.LastName = owner.LastName;
                ownerUpdated.Date = owner.Date;
                ownerUpdated.Description = owner.Description;
                ownerUpdated.Type = owner.Type;
                return Ok(_result);
            }
            else
            {
                return BadRequest("Atteinton! There is hack word in description");
            }
        }
    }
}
