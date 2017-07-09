using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DesignLibrary;
using DesignLibrary.Visitor;
using AdapterLibrary;

namespace DesignPattern.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timerComponentCreation.Enabled = true;  
        }

        private void btnAdapter_Click(object sender, EventArgs e)
        {
            ITarget ad = new Adapter();
            string s = ad.Request(5);

            txtResult.Text = s;
        }

        private void btnFactory_Click(object sender, EventArgs e)
        {
            Creator c = new Creator();
            IProduct product;

            txtResult.Text = "Factory pattern" + Environment.NewLine;
            for (int i = 1; i < 12; i++)
            {
                product = c.FactoryMethod(i);
                txtResult.Text += "Month: " + i + "   Avocados " + product.ShipFrom() + Environment.NewLine;
            }
        }

        private void btnStrategy_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            context.SwitchStrategy();

            Random r = new Random(37);
            txtResult.Text = "Strategy pattern" + Environment.NewLine;

            bool firstNumberInRow = true;
            for (int i = context._START; i <= context._START + 15; i++)
            {

                if (r.Next(3) == 2)
                {
                    txtResult.Text += "||" + Environment.NewLine;
                    context.SwitchStrategy();
                    firstNumberInRow = true;
                }

                if (!firstNumberInRow)
                {
                    txtResult.Text += " - ";
                }

                txtResult.Text += context.Algorithm().ToString();
                firstNumberInRow = false;
            }
        }

        private void btnComposite_Click(object sender, EventArgs e)
        {
            IComponent<string> album = new Composite<string>("Album");
            IComponent<string> point = album;

            string [] s;
            string command, parameter;

            txtResult.Text = "";
            StreamReader instream = new StreamReader("Composite.txt");
            do
            {
                string line = instream.ReadLine();
                if (line == null) return;

                txtResult.Text += line + Environment.NewLine;

                s = line.Split();
                command = s[0];

                if (s.Length > 1)
                    parameter = s[1];
                else
                    parameter = null;

                switch (command)
                {
                    case "AddSet":
                        IComponent<string> c = new Composite<string>(parameter);
                        point.Add(c);
                        point = c;
                        break;

                    case "AddPhoto":
                        point.Add(new Component<string>(parameter));
                        break;

                    case "Remove":
                        point = point.Remove(parameter);
                        break;

                    case "Find":
                        point = album.Find(parameter);
                        break;

                    case "Display":
                        txtResult.Text += album.Display(0) + Environment.NewLine;
                        break;
                    case "Quit":
                        break;

                }

            } while (!command.Equals("Quit"));
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            txtResult.Text = "Proxy Pattern" + Environment.NewLine;

            SubjectAccessor.ISubject subject = new SubjectAccessor.Proxy();

            //ISubject subject = new Proxy();
            txtResult.Text += subject.Request();
            txtResult.Text += subject.Request();
            
        }

        private void btnAbstractFactory_Click(object sender, EventArgs e)
        {
            txtResult.Text = "ABSTRACT FACTORY Pattern" + Environment.NewLine;

            IFactory factory = new Factory1();
            txtResult.Text += "Factory 1:" + Environment.NewLine;
            txtResult.Text += factory.getCar().getMerke() + Environment.NewLine;
            txtResult.Text += factory.getBike().getSize().ToString() + Environment.NewLine;
            txtResult.Text += Environment.NewLine;

            txtResult.Text += "Factory 2:" + Environment.NewLine;
            factory = new Factory2();
            txtResult.Text += factory.getCar().getMerke() + Environment.NewLine;
            txtResult.Text += factory.getBike().getSize().ToString() + Environment.NewLine;

        }

        private void btnObserver_Click(object sender, EventArgs e)
        {
            txtResult.Text = "OBSERVER Pattern" + Environment.NewLine;
            txtResult.Text += "Result is written to Output window" + Environment.NewLine;

            ObserverPattern.Subject subject = new ObserverPattern.Subject();
            ObserverPattern.Observer observer1 = new ObserverPattern.Observer(subject, "obs1", "\t");
            ObserverPattern.Observer observer2 = new ObserverPattern.Observer(subject, "obs2", "\t\t");
            subject.Go();
        }

        private void btnVisitor1_Click(object sender, EventArgs e)
        {
            txtResult.Text = "VISITOR Pattern #1" + Environment.NewLine;
            txtResult.Text += "Some of the result is written to Output window" + Environment.NewLine;

            Element objectStructure =
                new Element(
                    new Element(
                     new ElementWithLink(
                         new Element(
                             new Element(
                                 new ElementWithLink(
                                     new Element(null),
                                     new Element(
                                         null)))),
                                         new Element(
                                             new Element(
                                                 new Element(null))))));

            txtResult.Text += "Count the elements:" + Environment.NewLine;
            CountVisitor visitor = new CountVisitor();

            visitor.CountElements(objectStructure);
            txtResult.Text += "Number of Elements are: " + visitor.Count + Environment.NewLine;
        }

        private void btnComponent_Click(object sender, EventArgs e)
        {
            Component1 cd;
            int i;
            for (i = 0; i < 1000; i++)
            {
                cd = new Component1();
            }
        }

        private void timerComponentCreation_Tick(object sender, EventArgs e)
        {
            txtInstanceCount.Text = Component1.InstanceCount.ToString();
        }

        private void btnFacade_Click(object sender, EventArgs e)
        {
            Form frm = new FacadeBwPanel();
            frm.ShowDialog();
        }
    }
}
