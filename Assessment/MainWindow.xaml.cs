using System;
using System.IO;
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
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Assessment
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        // Changes Font of the Contact Info and Name on business card.
        private void FontChanged(object sender, SelectionChangedEventArgs e)
        {

            contact.FontFamily = (FontFamily)fonts.SelectedValue;
            name.FontFamily = (FontFamily)fonts.SelectedValue;
        }
        // Changes the backround of the Card on a change of the index.
        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {        
         
            if (colors.SelectedIndex != 5)
            {

            BrushConverter converter = new BrushConverter();

            businessCard.Fill =  (Brush)converter.ConvertFrom(colors.SelectedValue);
           
                gradient1.Visibility = Visibility.Hidden;
                gradient2.Visibility = Visibility.Hidden;
            }
            else
            {
                gradient1.Visibility = Visibility.Visible;
                gradient2.Visibility = Visibility.Visible;
            }
        }
        // Checks string to make sure its an int then converts to int and changes fontsize to that.
        private void FontSizer(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(fontSize.Text, @"^[0-9]+$"))
            {
                int fontsze = Convert.ToInt32(fontSize.Text);
                name.FontSize = fontsze;
                contact.FontSize = fontsze;
            }

        }
        // Changes where text appears on the Card.
        private void TextMove(object sender, SelectionChangedEventArgs e)
        {
            int cases = TextMover.SelectedIndex;
            switch (cases)
            {
                case 0:
                    contact.Margin = new Thickness(350, 141, 0, 0);
                    contact.Width = 350;
                    name.Margin = new Thickness(350, 92, 0, 0);
                    name.Width = 350;
                    break;
                case 1:
                    contact.Margin = new Thickness(350, 210, 0, 0);
                    contact.Width = 350;
                    name.Margin = new Thickness(350, 160, 0, 0);
                    name.Width = 350;
                    break;
                case 2:
                    contact.Margin = new Thickness(420, 141, 0, 0);
                    contact.Width = 175;
                    name.Margin = new Thickness(420, 92, 0, 0);
                    name.Width = 175;
                    break;
                case 3:
                    contact.Margin = new Thickness(532, 141, 0, 0);
                    contact.Width = 175;
                    name.Margin = new Thickness(532, 92, 0, 0);
                    name.Width = 175;
                    break;
                case 4:
                    contact.Margin = new Thickness(532, 214, 0, 0);
                    contact.Width = 175;
                    name.Margin = new Thickness(532, 170, 0, 0);
                    name.Width = 175;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        // Changes Gradient for the backround of the Card.
        private void GradientChange(object sender, SelectionChangedEventArgs e)
        {
            if(gradient1.SelectedValue!= null && gradient2.SelectedValue != null)
            {
                Color colorg = (Color)ColorConverter.ConvertFromString((String)gradient1.SelectedValue);
                Color colorg2 = (Color)ColorConverter.ConvertFromString((String)gradient2.SelectedValue);
                LinearGradientBrush GradientBrush = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 1)
                };
                GradientBrush.GradientStops.Add(new GradientStop(colorg, 0.0));
                GradientBrush.GradientStops.Add(new GradientStop(colorg2,1.0));
                businessCard.Fill = GradientBrush;
            }                           
        }


     // Saves all selected options for the business card.
        private void Save(object sender, RoutedEventArgs e)
        {
            SaveClass saved = new SaveClass();
            {

                saved.Name = name.Text;
                saved.Contact = contact.Text;
                saved.Font = fonts.Text;
                saved.Fontsize = fontSize.Text;
                saved.Brushcolor = colors.Text;
                saved.gradient1 = gradient1.Text;
                saved.gradient2 = gradient2.Text;
            }
            string json = JsonConvert.SerializeObject(saved, Formatting.Indented);
            File.WriteAllText(@"Test\test.json", json);
          
            
        }
        // Reloads saved file.
        private void Load(object sender, RoutedEventArgs e)
        {
            SaveClass load = JsonConvert.DeserializeObject<SaveClass>(File.ReadAllText(@"Test\test.json"));
            name.Text = load.Name;
            contact.Text = load.Contact;
            colors.Text = load.Brushcolor;
            fontSize.Text = load.Fontsize;
            fonts.Text = load.Font;
            gradient1.Text = load.gradient1;
            gradient2.Text = load.gradient2;
          
        }
    }
}

