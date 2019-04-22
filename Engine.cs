using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartUp.Context;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace StartUp
{
  public   class Engine
    {
       
        private readonly PharmacySystemDbContext context;

        public Engine(PharmacySystemDbContext context)
        {

            this.context = context;
        }

        public void Run()
        {

        //
        //this.context.Database.EnsureDeleted();
        //this.context.Database.EnsureCreated();
        //Console.WriteLine("Database Succesfully Created");
        //  return;
        //

            MenuCommands();
            Console.Write("Write Command number -> ");
            int commandNumber = int.Parse(Console.ReadLine());

            while (true)
            {
                if (commandNumber == 0)
                {

                    commandNumber = ExitCommand(commandNumber);

                    if (commandNumber == 0)
                    {
                        break;
                    }
                   
                   

                }

                if (commandNumber == 1)
                {
                    InsertCustomer();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");
                    
                    MenuCommands();
                    Console.Write("Write Command number -> ");

                }

                if (commandNumber == 2)
                {
                    InsertDoctor();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");

                }
                if (commandNumber == 3)
                {
                    InsertEmployee();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");
                }
                if (commandNumber == 4)
                {
                    AcceptOrders();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");
                }
                if (commandNumber == 5) 
                {
                    InsertMedicament();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");

                }
                if (commandNumber == 6)
                {
                    InsertRecipe();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");
                }
                if (commandNumber == 7)
                {
                    ViewAllOrders();
                    Console.Clear();
                    Console.WriteLine("PharmacyManagment System");

                    MenuCommands();
                    Console.Write("Write Command number -> ");
                }

                commandNumber = int.Parse(Console.ReadLine());

            }





        }

        private void AcceptOrders()
        {
            Console.Write("Enter CustomerId -> ");

            
                int customerId = int.Parse(Console.ReadLine());
            
            var customer = this.context.Customers.Where(f => f.Id == customerId).FirstOrDefault();

            if (customer == null)
            {
                Console.WriteLine("Invalid Customer Id");
                
                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    AcceptOrders();
                }
                return;
            }
            Console.Write("Enter EmployeeId");
            int employeeId = int.Parse(Console.ReadLine());

            var employee = this.context.Employees.Where(f => f.Id == employeeId).FirstOrDefault();

            if (employee == null)
            {

                Console.WriteLine("Invalid Employee Id");
                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    AcceptOrders();
                }
                return;

            }

            Order order = new Order()
            {
                Date = DateTime.Now,
                EmployeeId = employeeId,
                CustomerId = customerId

            };

            this.context.Orders.Add(order);
            Console.Write("Enter MedicamentId ->");

            try
            {
                int medicamentId = int.Parse(Console.ReadLine());

                var medicament = this.context.Medicaments.Where(m => m.Id == medicamentId).FirstOrDefault();

                OrdersMedicaments ordersMedicaments = new OrdersMedicaments()
                {
                    OrderId = order.Id,
                    MedicamentId = medicamentId
                   
                }
                ;

                CustomerMedicaments customerMedicaments = new CustomerMedicaments()
                {
                    CustomerId = order.CustomerId,
                    MedicamentId = medicamentId
                };



                this.context.OrdersMedicaments.Add(ordersMedicaments);

                this.context.SaveChanges();
            }
            catch (ArgumentNullException )
            {

                Console.WriteLine("Invalid Medicament Id");
                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    AcceptOrders();
                }
                return;
            }

           

            
            this.context.SaveChanges();

            Console.Write("Do you want to register another Order ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if (command == "Yes")
            {
                AcceptOrders();
            }


           
        }

        private void ViewAllOrders()
        {

            var orders = this.context.OrdersMedicaments.Include(c=>c.OrderMedicament)
                .Include(d=>d.Order)
                .ThenInclude(s=>s.Customer);
            Console.WriteLine("All Orders");
            foreach (var item in orders)
            {
                Console.WriteLine($"Customer Name {item.Order.Customer.FisrtName} {item.Order.Customer.LastName}, " +
                    $"Date - {item.Order.Date},\n" +
                    $"Medicament Name - {item.OrderMedicament.Name}, " +
                    $"Medicament Price - {item.OrderMedicament.Price}, " +
                    $"Require Recipe - {item.OrderMedicament.RequireRecipe}, " +
                    $"Recipe Number - {item.OrderMedicament.RecipeNumber}");
                Console.WriteLine();
            }
            string command = string.Empty;
            Console.Write("Do you want to exit Yes or No -> ");
            command = Console.ReadLine();

            if (command == "Yes")
            {
                return;
            }

            
        }

        private void InsertCustomer()
        {
            Customer customer;

            Console.WriteLine("Create Customer Command");
            Console.Write("First Name -> ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name ->");
            string lastName = Console.ReadLine();
            Console.Write("Telephone Number ->");
            string telephoneNumber = Console.ReadLine();
            Console.Write("Birth Date(optional) in Format (dd-MM-yyyy) ->  ");
            string date = Console.ReadLine();

            if (string.IsNullOrEmpty(date))
            {
                customer = new Customer()
                {
                    FisrtName = firstName,
                    LastName = lastName,
                    TelephoneNumber = telephoneNumber,



                };
            }
            else
            {
                 customer = new Customer()
                {
                    FisrtName = firstName,
                    LastName = lastName,
                    TelephoneNumber = telephoneNumber,


                    BirthDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

            }



            this.context.Customers.Add(customer);
           

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Invalid Customer");

                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    InsertCustomer();
                }
                return;
                
            }
            Console.WriteLine("Customer has Successfully Registered ");

            Console.Write("Do you want to register another customer ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if(command=="Yes")
            {
                InsertCustomer();
            }

        }

        private int ExitCommand(int commandNumber)
        {
            Console.WriteLine("are you sure you want to exit");
            Console.Write("Yes or No ->  ");
            string result = Console.ReadLine();
            if (result == "Yes")
            {
                Console.WriteLine("You exit successfully");
                return 0;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("PharmacyManagment System");
                MenuCommands();
                Console.Write("Write Command number -> ");
                commandNumber = int.Parse(Console.ReadLine());
            }
            if (commandNumber == 0)
            {
              commandNumber=  ExitCommand(commandNumber);
            }
            else
            {
                return commandNumber;
            }

            return commandNumber;
        }

        private  void MenuCommands()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1:Insert Customer");
            Console.WriteLine("2:Insert Doctor");
            Console.WriteLine("3:Insert Employee");
            Console.WriteLine("4:Accept Order");
            Console.WriteLine("5:Insert Medicament");
            Console.WriteLine("6:Insert Recipe");
            Console.WriteLine("7:View all orders");
            Console.WriteLine("0:Exit");
        }


        private void InsertDoctor()
        {
            Doctor doctor;
            Console.WriteLine("Insert Doctor");

            Console.Write("First Name -> ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name ->");
            string lastName = Console.ReadLine();
            Console.Write("Speciality ->");
            string speciality = Console.ReadLine();
            doctor = new Doctor
            {
                FirstName = firstName,
                LastName = lastName,
                Speciality = speciality
            };
            this.context.Doctors.Add(doctor);

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Invalid Doctor");

                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    InsertDoctor();
                }
                return;

            }

            Console.WriteLine("Doctor has Successfully Registered ");

            Console.Write("Do you want to register another doctor ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if (command == "Yes")
            {
                InsertDoctor();

            }
        }

        private void InsertEmployee()
        {
            Employee employee;
            Console.WriteLine("Insert Empoyee");

            Console.Write("First Name -> ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name ->");
            string lastName = Console.ReadLine();
            Console.Write("Possition ->");
            string possition = Console.ReadLine();
            employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Possition=possition
            };
            this.context.Employees.Add(employee);

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Invalid Employee");

                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    InsertRecipe();
                }
                return;

            }

            Console.WriteLine("Employee has Successfully Registered ");

            Console.Write("Do you want to register another employee ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if (command == "Yes")
            {
                InsertEmployee();
            }
        }

        private void InsertRecipe()
        {
            Recipe recipe;
            Console.WriteLine("Insert Recipe");

            Console.Write("Number -> ");
            string number = Console.ReadLine();
            Console.Write("Medicament Id ->");
            int medicamentId = context.Medicaments.Where(a => a.Id == int.Parse(Console.ReadLine())).FirstOrDefault().Id;
            Console.Write("Doctor Id ->");
            int doctorId = context.Doctors.Where(d => d.Id == int.Parse(Console.ReadLine())).FirstOrDefault().Id;
            Console.Write("Customer Id ->");
            int customerId = context.Customers.Where(c => c.Id == int.Parse(Console.ReadLine())).FirstOrDefault().Id;
            Console.Write("Dose per Day ->");
            decimal dosePerDay = decimal.Parse(Console.ReadLine());
            


           

            try
            {
                this.context.SaveChanges();
                recipe = new Recipe
                {
                    Number = number,
                    MedicamentId = medicamentId,
                    DoctorId = doctorId,
                    CustomerId = customerId,
                    DosePerDay = dosePerDay,

                };
                this.context.Recipies.Add(recipe);

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Recipe");

                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    InsertRecipe();
                }
                return;

            }

            Console.WriteLine("Recipe has Successfully Registered ");

            Console.Write("Do you want to register another Recipe ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if (command == "Yes")
            {
                InsertRecipe();
            }
        }

        private void InsertMedicament()
        {
            Medicament medicament;
            Console.WriteLine("Insert Medicament");

            Console.Write("Name -> ");
            string medicamentName = Console.ReadLine();
            Console.Write("Require Recipe ->");
            bool requireRecipe =bool.Parse( Console.ReadLine());
            string recipeNumber=string.Empty;
            if (requireRecipe)
            {
                Console.Write("Recipe Number");
                recipeNumber = Console.ReadLine();
            }
            Console.Write("Price ->");
            decimal price = decimal.Parse(Console.ReadLine());

            
           


            medicament = new Medicament
            {
                Name=medicamentName,
                RequireRecipe=requireRecipe,
                RecipeNumber=recipeNumber,
                Price=price


            };
            this.context.Medicaments.Add(medicament);

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Invalid Medicament");

                Console.Write("Do you want to add again Yes or No -> ");
                string s = Console.ReadLine();

                if (s == "Yes")
                {
                    InsertMedicament();
                }
                return;

            }

            Console.WriteLine("Medicament has Successfully Registered ");

            Console.Write("Do you want to register another Medicament ->");
            Console.WriteLine("Yes or No");
            string command = Console.ReadLine();
            if (command == "No")
            {
                return;
            }
            else if (command == "Yes")
            {
                InsertMedicament();
            }
        }
      
    }
}
