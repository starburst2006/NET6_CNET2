using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return _db.Persons.Include(x=>x.Contracts).Include(x=>x.HomeAddress);   // aby načetl i vazbené tabulky, přidám je do include. Jinak načte jen tabulku persons
        }

        //vypiš osobu dle emailu
        [HttpGet("GetByEmail/{email}")]
        public Person GetByEmail(string email)
        {
           return _db.Persons.Include(x => x.Contracts).Include(x => x.HomeAddress).Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        [HttpGet("GetById/{id}")]
        public Person GetById(int id)
        {
            return _db.Persons.Include(x => x.Contracts).Include(x => x.HomeAddress).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
