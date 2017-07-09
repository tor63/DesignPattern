using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary
{
    public interface IComponent<T>
    {
        void Add(IComponent<T> c);
        IComponent<T> Remove(T s);
        string Display(int depth);
        IComponent<T> Find(T s);
        T Name { get; set; }
    }


    public class Component<T> : IComponent<T>
    {
        public Component(T name)
        {
            Name = name; //Betinger ToString() implementet for T
        }
        #region IComponent<T> Members
        public void Add(IComponent<T> c)
        {
            throw new NotImplementedException();
        }

        public IComponent<T> Remove(T s)
        {
            //Error throw new NotImplementedException();
            return this;
        }

        public string Display(int depth)
        {
            return new string('-', depth) + Name + Environment.NewLine;
        }

        public IComponent<T> Find(T s)
        {
            if (s.Equals(Name))
                return this;
            else
                return null;
        }

        public T Name { get; set; }
        #endregion
    }

    public class Composite<T> : IComponent<T>
    {
        //Dete er det spesielle for composite. Inneholder en mengde av Interfaced den implementerer.
        //I dette tilfelle: IComponent<T>
        List<IComponent<T>> list;

        public Composite(T name)
        {
            Name = name; //Betinger ToString() implementet for T
            list = new List<IComponent<T>>();
        }

        IComponent<T> holder = null;

        #region IComponent<T> Members
        public void Add(IComponent<T> c)
        {
            list.Add(c);
        }

        public IComponent<T> Remove(T s)
        {
            holder = this;
            IComponent<T> p = holder.Find(s);
            if (holder != null)
            {
                (holder as Composite<T>).list.Remove(p);
                return holder;
            }
            else
                return this;
        }

        public string Display(int depth)
        {
            StringBuilder s = new StringBuilder(new string('-', depth));
            s.Append("Set " + Name + " length : " + list.Count + Environment.NewLine);

            foreach (IComponent<T> c in list)
            {
                s.Append(c.Display(depth + 2));
            }
            return s.ToString();
        }

        public IComponent<T> Find(T s)
        {
            holder = this;
            if (Name.Equals(s)) return this;
            IComponent<T> found = null;

            foreach (IComponent<T> c in list)
            {
                found = c.Find(s);
                if (found != null)
                    break;
            }
            return found;
        }

        public T Name { get; set; }
        #endregion
    }


}
