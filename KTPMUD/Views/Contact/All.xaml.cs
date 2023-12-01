using Models;
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

namespace KTPMUD.Views.Contact
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class All : UserControl
    {
        public All()
        {
            InitializeComponent();
        }

        internal ViewModels.LienHeViewModel Model => ((ViewModels.LienHeViewModel)DataContext);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Remove();
        }

        private void Selected(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                Model.SelectedIndex = ListView.SelectedIndex;
            }
        }
    }

    public class Index : BaseView<All>
    {
        protected override void RenderCore()
        {

            var model = new ViewModels.LienHeViewModel();
            Action bind = () =>
            {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }
}