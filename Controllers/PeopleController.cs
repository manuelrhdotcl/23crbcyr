using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _23crbcyr.Entities;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace _23crbcyr.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : Controller
    {

       
        /// <summary>
        /// get all people in database
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [EnableCors("AllowsAll")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> personList;
            using (DataDbContext db = new DataDbContext())
            {
                personList = db.Person.ToList();
            }

            return Ok(personList);

        }

        /// <summary>
        /// get detail of one person
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Person person;
            using (DataDbContext db = new DataDbContext())
            {
                person = db.Person.Find(id);
            }

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);

        }

        /// <summary>
        /// add person to database
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Authorize]
        public IActionResult Post(Person person)
        {
            ICollection<ValidationResult> results;
            if (!Helpers.Validate(person, out results))
            {
                return BadRequest(results.ToString());
            }

            using (DataDbContext db = new DataDbContext())
            {
                try
                {
                    db.Add(person);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return StatusCode(201);
        }

        /// <summary>
        /// update person data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, Person person)
        {
            using (DataDbContext db = new DataDbContext())
            {
                var personObj = db.Person.Find(id);

                if (person == null)
                {
                    return NotFound();
                }

                personObj.rut = person.rut;
                personObj.name = person.name;
                personObj.lastName = person.lastName;
                personObj.age = person.age;

                db.SaveChanges();
            }

            return Ok();
        }

        /// <summary>
        /// delete person from database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            using (DataDbContext db = new DataDbContext())
            {
                var person = db.Person.Find(id);

                if (person == null)
                {
                    return NotFound();
                }

                db.Person.Remove(person);
            }

            return Ok();
        }

    }
}