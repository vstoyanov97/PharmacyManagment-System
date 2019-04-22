using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
   public class Order
    {
        public Order()
        {
            this.OrderMedicaments = new HashSet<OrdersMedicaments>();

        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

       

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrdersMedicaments> OrderMedicaments { get; set; }
    }
}
