using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
  public   class Medicament
    {
        public Medicament()
        {
            this.CustomerMedicaments = new HashSet<CustomerMedicaments>();
            this.OrderMedicaments = new HashSet<OrdersMedicaments>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public bool RequireRecipe { get; set; }

        public string RecipeNumber { get; set; }

        public decimal Price { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Pharmacist { get; set; }

        public ICollection<CustomerMedicaments> CustomerMedicaments { get; set; }

        public ICollection<OrdersMedicaments> OrderMedicaments { get; set; }

        public Recipe Recipe { get; set; }

    }
}
