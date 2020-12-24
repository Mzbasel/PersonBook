using System;

namespace PersonBook
{
    class Program
    { 
        static void Main(string[] args)
        {
            IPersonService personService =
            NinjectInstanceFactory.GetInstance<IPersonService>();

            Console.WriteLine(@"1. List
2. Add Person
3. Update Person
4. Delete Person
5. Exit
");
            
            string operation = null;

            while (operation != "5")
            {
                Console.Write("Please select an operation: ");
                operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        personService.List();
                        break;
                    case "2":
                        Console.Write("Please enter your First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Please enter your Last Name: ");
                        string lastName = Console.ReadLine();
                        personService.AddPerson(firstName, lastName);
                        break;
                    case "3":
                        Console.Write("Please enter the id of person which you want to edit: ");
                        string id = Console.ReadLine();
                        Console.Write("Plase enter the first name: ");
                        string updatedFirstName = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        string updatedLastName = Console.ReadLine();
                        personService.UpdatePerson(Convert.ToInt32(id), updatedFirstName, updatedLastName);
                        break;
                    case "4":
                        Console.Write("Please enter the id of person which you want to delete: ");
                        string deletedId = Console.ReadLine();
                        personService.DeletePerson(Convert.ToInt32(deletedId));
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("No operation has been selected");
                        break;
                }
            }
        }
    }
}
