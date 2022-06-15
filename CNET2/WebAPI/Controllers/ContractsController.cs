using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        [HttpGet]
        public List<Contract> GetContracts()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\Student\source\repos\starburst2006\PersonDataset\dataset.xml");

            var contracts = dataset.SelectMany(c => c.Contracts).ToList();
                       
            return contracts;
        }



    }
}
