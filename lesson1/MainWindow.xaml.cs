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

namespace lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestWin.Title = "Asirush";
/*
            Button btn = new Button();
            btn.Content = "play";
            btn.Width= 200;
            btn.Height= 50;

            TestWin.Content = btn;
*/
        }

        private void btnShowAlertQuick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            MessageBox.Show("Work in - " + DateTime.Now);
        }
    }
}
