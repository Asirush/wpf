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
using System.Windows.Shapes;

namespace lesson4
{
    /// <summary>
    /// Interaction logic for MainAuthWindow.xaml
    /// </summary>
    public partial class MainAuthWindow : Window
    {
        public MainAuthWindow()
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
            //List<Operator> operators = new List<Operator>();
            //operators.Add(new Operator() { Prefix = "+7 777", Logo = "https://play-lh.googleusercontent.com/YSMd2aaFMmeUZrnivoPFXVmfE6756FefmGhKAWEIvbvMju5jhlIEj_bXlKiP1wMyiPk", Name = "Beeline", Percent = 0.15 });
            //lvOperatorList.ItemsSource = operators;

        }

        private void miOperatorList_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Source = new Uri("pageOperatorList.xaml", UriKind.RelativeOrAbsolute);
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class Operator
    {
        public int OperatorId { get; set; }
        public string Prefix { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }
        public Operator() { }
    }
}
