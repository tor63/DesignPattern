using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary.Visitor
{
    public abstract class IElement
    {
        public abstract void Accept(IVisitor visitor);
    }

    public class Element : IElement
    {
        public Element Next { get; set;}
        public Element Link { get; set; }
        public Element () {}

        public Element(Element next) {
            Next = next;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ElementWithLink : Element
    {
        public ElementWithLink(Element link, Element next)
        {
            Next = next;
            Link = link;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
