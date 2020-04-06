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
        public ActionResult<IEnumerable<Person>> Get()
        {
            var persona = new Person()
            {
                rut = "1-9",
                name = "manuel",
                lastName = "paillafil",
                age = 34
            };

            return new Person[] { persona };
        }

        /// <summary>
        /// GET /people/:id -> devuelve el curso correspondiente al id entregado. Si no existe
        /// una persona con :id entonces debe devolver el status 404
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "1";
        }

        /// <summary>
        /// POST /people + json -> Permite crear una persona con los datos proporcionados en
        /// el json.Devuelve status 201 si se creó exitosamente. Si los datos son inválidos
        /// debe devolver status 400.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT /people/:id + json -> Actualiza una persona con el id entregado y los campos
        /// incluídos en el json.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// DELETE /people/:id -> Elimina una persona con el id entregado y devuelve status
        /// 200. Si el curso no existe devuelve status 404.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}