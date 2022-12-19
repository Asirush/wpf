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

namespace lesson4
{
    /// <summary>
    /// Interaction logic for pageOperatorList.xaml
    /// </summary>
    public partial class pageOperatorList : Page
    {
        public pageOperatorList()
        {

            InitializeComponent();

            // first method

            //WrapPanel wp = new();
            //wp.Children.Add(new Label() { Content = "+7" });
            //wp.Children.Add(new Label() { Content = "logo" });
            //wp.Children.Add(new Label() { Content = "beeline" });
            //wp.Children.Add(new Label() { Content = "5%" });
            //lbxOperatorList.Items.Add(wp);

            // second method
            List<Operator> operators = new List<Operator>();
            operators.Add(new Operator() { Prefix = "+7 777", Logo = "https://play-lh.googleusercontent.com/YSMd2aaFMmeUZrnivoPFXVmfE6756FefmGhKAWEIvbvMju5jhlIEj_bXlKiP1wMyiPk", Name = "Beeline", Percent = 0.15 });
            lvOperatorList.ItemsSource = operators;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Operator data = (Operator)lvOperatorList.SelectedItem;
        }
    }
}
