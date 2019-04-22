using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
   public class Customer
    {
        public Customer()
        {
            this.CustomerMedicaments = new HashSet<CustomerMedicaments>();

            this.Orders = new HashSet<Order>();
            this.Recipes = new HashSet<Recipe>();

    }
    public int Id { get; set; }

        public string FisrtName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public DateTime BirthDate { get; set; }


       public ICollection<CustomerMedicaments> CustomerMedicaments { get; set; }
      public  ICollection<Order> Orders { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

    }
}
