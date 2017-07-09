using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdapterLibrary
{
    public partial class Component1 : Component
    {
        public readonly int InstanceID;
        private static int NextInstanceID = 0;
        private static long ClassInstanceCount = 0;

        public Component1()
        {
            InitializeComponent();

            InstanceID = NextInstanceID++;
            ClassInstanceCount++;
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        ~Component1()
        {
            ClassInstanceCount--;
        }

        public static long InstanceCount
        {
            get
            {
                return ClassInstanceCount;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
