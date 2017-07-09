using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    class SubjectAccessor
    {
        public interface ISubject
        {
            string Request();
        }

        private class Subject
        {
            public string Request_01()
            {
                return "Subject Request_01  -  Chooes left door" + Environment.NewLine;
            }
        }

        public class Proxy : ISubject
        {
            Subject subject;


            #region ISubject Members
            public string Request()
            {
                string s = "";
                if (subject == null)
                {
                    s += "Subject Inactive" + Environment.NewLine;
                    subject = new Subject();
                }
                s += "Subject Active" + Environment.NewLine;
                s += "Proxy: Call to " + subject.Request_01();
                return s;
            }
            #endregion
        }
    }
}
