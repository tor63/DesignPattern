using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary.Visitor
{
    public interface IVisitor
    {
        void Visit(Element element);
        void Visit(ElementWithLink element);
    }

    public class CountVisitor : IVisitor
    {
        public int Count { get; set; }

        public void CountElements(Element element)
        {
            element.Accept(this);
            if (element.Link != null) CountElements(element.Link);
            if (element.Next != null) CountElements(element.Next);
        }



        #region IVisitor Members

        public void Visit(Element element)
        {
            Count++;
        }

        public void Visit(ElementWithLink element)
        {
            Console.WriteLine("Visit(ElementWithLink) NOT COUNTED");
        }

        #endregion
    }
}
