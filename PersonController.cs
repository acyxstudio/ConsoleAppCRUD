using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ConsoleAppCRUD
{
    public class PersonController : ApiController
    {
        private static List<Person> persons = new List<Person>();

        public IEnumerable<Person> Get()
        {
            return persons;
        }

        public IHttpActionResult Get(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        public IHttpActionResult Post(Person person)
        {
            person.Id = persons.Count + 1;
            persons.Add(person);
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        public IHttpActionResult Put(int id, Person person)
        {
            var existingPerson = persons.FirstOrDefault(p => p.Id == id);
            if (existingPerson == null)
                return NotFound();

            existingPerson.FirstName    =   person.FirstName;
            existingPerson.LastName     =   person.LastName;
            existingPerson.EmailAddress =   person.EmailAddress;
            existingPerson.NotesField   =   person.NotesField;
            existingPerson.CreationTime =   person.CreationTime;

            return Ok(existingPerson);
        }

        public IHttpActionResult Delete(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return NotFound();

            persons.Remove(person);
            return Ok(person);
        }
    }
}
