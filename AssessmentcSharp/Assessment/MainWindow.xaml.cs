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

namespace Assessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
               
            
        }

        private void FontChanged(object sender, SelectionChangedEventArgs e)
        {
           
            contact.FontFamily = (FontFamily)fonts.SelectedValue;
            name.FontFamily = (FontFamily)fonts.SelectedValue;
            

        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(Brushes.Purple.GetType());
            SolidColorBrush temp = (SolidColorBrush)colors.SelectedValue;
            //businessCard.Fill = colors.SelectedValue;
        }

        private void FontSize(object sender, TextChangedEventArgs e)
        {
            if(fontSize.Text == "1")
            {
                Console.WriteLine("HI");
            }
        }
    }
}
