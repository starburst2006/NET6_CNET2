using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // vypiš všechny osoby
        [HttpGet("GetAll")]
        public List<Person> GetPeople()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\Student\source\repos\starburst2006\PersonDataset\dataset.xml");
            return dataset; 
        }

        //vypiš osobu dle emailu
        [HttpGet("GetByEmail/{email}")]
        public Person GetByEmail(string email)
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\Student\source\repos\starburst2006\PersonDataset\dataset.xml");
            
            return dataset.Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();


        }


    }


}
