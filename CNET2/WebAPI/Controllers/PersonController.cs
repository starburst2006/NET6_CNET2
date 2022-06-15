using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _db;

        public PersonController(PersonContext db)
        {
            _db = db;
        }
        
        // vypiš všechny osoby
        [HttpGet("GetAll")]
        public IEnumerable<Person> GetPeople()
        {
            return _db.Persons; 
        }

        //vypiš osobu dle emailu
        [HttpGet("GetByEmail/{email}")]
        public Person GetByEmail(string email)
        {
           return _db.Persons.Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
