using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTPMUD.Views
{
    public class ContentView : IView
    {
        public string Title { get; set; }
        public virtual object GetContent() { return null; }
        protected virtual void RenderCore() { }
    }
    public class BaseView<TView> : ContentView
        where TView : UIElement, new() {
        
        public TView MainContent { get; set; }
        public override object GetContent()
        {
            if (MainContent == null)
            {
                MainContent = new TView();

                var uc = MainContent as UserControl;
                if (uc != null)
                {
                    var label = uc.FindName("title") as Label;
                    if (label != null)
                    {
                        Title = label.Content?.ToString();
                        ((Panel)label.Parent).Children.Remove(label);
                    }
                }

                RenderCore();
            }

            return MainContent;
        }
    }
}
