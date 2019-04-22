using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
   public class Employee
    {
        public Employee()
        {
            this.Orders = new HashSet<Order>();
            this.SalesMedicaments = new HashSet<Medicament>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Possition { get; set; }

       public ICollection<Order> Orders { get; set; }
        public ICollection<Medicament> SalesMedicaments { get; set; }
    }
}
