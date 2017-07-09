using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK.DesignPattern.DAL;
using System.Collections.Generic;
using DesignLibrary;
using System.Linq;
using System.IO;

namespace TK.DesignLibrary.UnitTest
{
    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void Iterator_Test01()
        {
            //Enumerator = iterator
            IEnumerable<Person> people = People.GetPeople();

            var enumerator = people.GetEnumerator();
            while (enumerator.MoveNext())
            {
                //TestContext.WriteLine(enumerator.Current.LastName);
                Console.WriteLine(enumerator.Current.LastName);
            }

            Assert.IsNotNull(enumerator);
        }

        [TestMethod]
        public void Iterator_FibonacciEnumerator()
        {
            var sequence = new FibonacciSequence(10);
            foreach (var item in sequence)
                Console.WriteLine(item);

            Assert.IsNotNull(sequence);
        }

        [TestMethod]
        public void Iterator_Mp3Iterator()
        {
            //Lister ut fil-informasjon
            //Egentlig laget til for mp3 filtype men kan benyttes for ulike typer.
            string searchText = "";
            var path = Directory.GetCurrentDirectory();
            var mp3s = new MP3Locator(path);
            foreach (var mp3 in mp3s
                .Where(m => m.Name.Contains(searchText) ||
                            m.Directory.Name.Contains(searchText) ||
                            m.Directory.Parent.Name.Contains(searchText)))
            {
                Console.WriteLine("Name: " + mp3.Name + " - Parent: " + mp3.Directory.Parent.Name);
            }
            Assert.IsNotNull(mp3s);
        }
    }
}
