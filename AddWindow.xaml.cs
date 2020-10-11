using _475Lab5.ViewModel;
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

namespace _475Lab5.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window, IClosable
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(System.Object sender, RoutedEventArgs e)
        {
            textBox.Text = String.Empty;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            //textBox.Clear();
            //textBox1.Clear();
            //textBox2.Clear();

        }

        private void Button1_Click(System.Object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Cancelled");
            textBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }


    }
}
