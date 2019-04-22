using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
  public  class Recipe
    {
        public int Id { get; set; }


       public string Number { get; set; }

       public int MedicamentId { get; set; }

        public Medicament Medicament { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public decimal DosePerDay { get; set; }


    }
}
