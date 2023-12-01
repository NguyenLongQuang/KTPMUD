using KTPMUD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTPMUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MVC.Register(this, result => {
                var view = (ContentView)result.View;

                MainContent.Child = (UIElement)view.GetContent();
                if (view.Title != null)
                {
                    MainCaption.Content = view.Title;
                }
            });

            foreach (Button btn in MainActions.Children)
            {
                btn.Click += (s, e) =>
                {
                    MVC.Execute(btn.Name);
                    //var view = new MainContent(btn.Name + ".All");
                    //MainContent.Child = view;
                    //if (view.Caption != null) {
                    //    MainCaption.Content = view.Caption;
                    //}

                };
            }
        }
    }
}
