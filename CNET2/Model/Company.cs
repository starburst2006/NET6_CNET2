using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Company
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;    
        public Address? Address { get; set; }

        public List<Contract>? contracts { get; set; }

    }
}
