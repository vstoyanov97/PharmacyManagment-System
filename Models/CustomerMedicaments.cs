using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
  public  class CustomerMedicaments
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int MedicamentId { get; set; }
        public Medicament CustomerMedicament { get; set; }


    }
}
