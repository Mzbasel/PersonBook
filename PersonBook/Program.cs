using System;
using System.Collections.Generic;

namespace PersonBook
{
    class Program
    {
        private const int ShowList = 1;
        private const int Add = 2;
        private const int Update = 3;
        private const int Delete = 4;
        private const int Exit = 5;

        static void Main(string[] args)
        {
            var personService =
            NinjectInstanceFactory.GetInstance<IPersonService>();

            Menu();
            
            string operation = null;

            while (operation != "5")
            {
                Console.Write("Please select an operation: ");
                operation = Console.ReadLine();

                switch (Convert.ToInt32(operation))
                {
                    case ShowList:
                        personService.List();
                        break;
                    case Add:
                        Console.Write("Please enter your First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Please enter your Last Name: ");
                        string lastName = Console.ReadLine();
                        personService.AddPerson(firstName, lastName);
                        break;
                    case Update:
                        Console.Write("Please enter the id of person which you want to edit: ");
                        string id = Console.ReadLine();
                        Console.Write("Plase enter the first name: ");
                        string updatedFirstName = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        string updatedLastName = Console.ReadLine();
                        personService.UpdatePerson(Convert.ToInt32(id), updatedFirstName, updatedLastName);
                        break;
                    case Delete:
                        Console.Write("Please enter the id of person which you want to delete: ");
                        string deletedId = Console.ReadLine();
                        personService.DeletePerson(Convert.ToInt32(deletedId));
                        break;
                    case Exit:
                        break;
                    default:
                        Console.WriteLine("No operation has been selected");
                        break;
                }
            }
        }

        private static void Menu()
        {
          Console.WriteLine(@"1. List
2. Add Person
3. Update Person
4. Delete Person
5. Exit
");
        }
    }
}
