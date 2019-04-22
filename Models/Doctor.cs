using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
  public  class Doctor
    {
        public Doctor()
        {

            this.Medicaments = new HashSet<Medicament>();
            this.Recipes = new HashSet<Recipe>();
        }


        public int Id { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set; }

        public string Speciality { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

    }
}
