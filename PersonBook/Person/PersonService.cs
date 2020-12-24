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
            if(firstName.Equals("") || lastName.Equals(""))
            {
                throw new Exception("First name or Last name can't be empty");
            }

            if(_person.Count > 0)
            {
                var lastIndexInTheList = _person[_person.Count - 1];

                _person.Add(new Person
                {
                    Id = Utils.GenerateId(lastIndexInTheList.Id),
                    FirstName = firstName,
                    LastName = lastName
                });
            }
            else
            {
                _person.Add(new Person
                {
                    Id = 1,
                    FirstName = firstName,
                    LastName = lastName
                });
            }
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

            if(firstName == null)
            {
                firstName = updatedPerson.FirstName;
            }

            if(lastName == null)
            {
                lastName = updatedPerson.LastName;
            }

            updatedPerson.FirstName = firstName;
            updatedPerson.LastName = lastName;
        }
    }
}
