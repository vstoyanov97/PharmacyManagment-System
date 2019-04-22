using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
  public  class OrdersMedicaments
    {

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MedicamentId { get; set; }
        public Medicament OrderMedicament { get; set; }
    }
}
