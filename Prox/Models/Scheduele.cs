using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Prox.Models
{
    public class Scheduele
    {
        public int ID { get; set; }


        public string? Name { get; set; }

        public string? Description { get; set; }


        public string? Problems { get; set; }


        public DateTime Datetime2{get; set;}


        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zipcode { get; set; } 
        
        public string? Email { get; set; }



      public IEnumerable<Scheduele> Schedueles { get; set; }









    }
}
