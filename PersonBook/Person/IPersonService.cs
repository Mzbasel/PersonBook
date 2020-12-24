using System;
using System.Collections.Generic;

namespace PersonBook
{
    public interface IPersonService
    {
        public void List();

        public void AddPerson(string firstName, string lastName);

        public void UpdatePerson(int id, string firstName, string lastName);

        public void DeletePerson(int id); 
    }
}
