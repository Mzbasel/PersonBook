using System;
using System.Collections.Generic;

namespace PersonBook
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _person;

        public PersonService(List<Person> person)
        {
            _person = person;
        }

        public void AddPerson(string firstName, string lastName)
        {
            if (firstName.Equals("") || lastName.Equals(""))
            {
                Console.WriteLine("First name or Last name can't be empty");
            }

            _person.Add(new Person
            {
                Id = _person.Count > 0 ? Utils.GenerateId(_person[_person.Count - 1].Id) : 1,
                FirstName = firstName,
                LastName = lastName
            });
        }

        public void DeletePerson(int id)
        {
            var removePerson = _person.Find(p => p.Id == id);
            _person.Remove(removePerson);
        }

        public void List()
        {
            if(_person.Count == 0)
            {
                Console.WriteLine("Empty List");
            }

            foreach (var person in _person)
            {
                Console.WriteLine($"Id: {person.Id} First Name: {person.FirstName}" +
                    $" Last Name: {person.LastName}");
            }
        }

        public void UpdatePerson(int id, string firstName, string lastName)
        {
            var updatedPerson = _person.Find(p => p.Id == id);

            try
            {
                if (firstName.Equals(""))
                {
                    firstName = updatedPerson.FirstName;
                }

                if (lastName.Equals(""))
                {
                    lastName = updatedPerson.LastName;
                }

                updatedPerson.FirstName = firstName;
                updatedPerson.LastName = lastName;
            }
            catch(Exception e)
            {
                Console.WriteLine("There is no user with this Id");
            }
        }
    }
}
