using System;
using System.Collections;
using System.Collections.Generic;
using TK.DesignPattern.DAL;

namespace DesignLibrary
{
    public class FacadeForEach
    {
        //View the MSIL code for the underlaying code. They are almost equal
        public FacadeForEach()
        {
            IEnumerable<Person> people = People.GetPeople();
            ManualEnumeration(people);
        }

        private void ManualEnumeration(IEnumerable<Person> people)
        {
            var enumerator = people.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);
        }

        private void ForeachEnumeration(IEnumerable<Person> people)
        {
            //Facade for the enumerator. It hides the complexity of the 
            foreach (var person in people)
                Console.WriteLine(person);
        }


    }
}
