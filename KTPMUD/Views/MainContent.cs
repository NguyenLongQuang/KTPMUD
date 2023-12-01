using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTPMUD
{
    internal class MainContent : Grid
    {
        static string assembly;
        public object Caption { get; set; }
        public MainContent(string name)
        {
            if (assembly == null)
            {
                assembly = this.GetType().Assembly.GetName().Name;
            }

            var type = Type.GetType($"{assembly}.Views.{name}");
            var view = (UserControl)Activator.CreateInstance(type);

            this.Children.Add(view);

            var label = view.FindName("title") as Label;
            if (label != null)
            {
                Caption = label.Content;
                ((Panel)label.Parent).Children.Remove(label);
            }
        }
    }
}
