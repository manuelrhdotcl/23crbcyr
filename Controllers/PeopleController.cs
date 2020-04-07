using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _23crbcyr.Entities;

namespace _23crbcyr.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : Controller
    {
        /// <summary>
        /// GET /people -> devuelve la lista completa de las personas existentes
        /// </summary>
        /// <returns></returns>
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
        /// GET /people/:id -> devuelve el curso correspondiente al id entregado. Si no existe
        /// una persona con :id entonces debe devolver el status 404
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person;
            using (DataDbContext db = new DataDbContext())
            {
                person = db.Person.Find(id);
            }

            if (person != null)
            {
                return NotFound();
            }

            return Ok(person);

        }

        /// <summary>
        /// POST /people + json -> Permite crear una persona con los datos proporcionados en
        /// el json.Devuelve status 201 si se creó exitosamente. Si los datos son inválidos
        /// debe devolver status 400.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            using (DataDbContext db = new DataDbContext())
            {
                try
                {
                    db.Add(person);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return StatusCode(201);
        }

        /// <summary>
        /// PUT /people/:id + json -> Actualiza una persona con el id entregado y los campos
        /// incluídos en el json.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
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
        /// DELETE /people/:id -> Elimina una persona con el id entregado y devuelve status
        /// 200. Si el curso no existe devuelve status 404.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
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