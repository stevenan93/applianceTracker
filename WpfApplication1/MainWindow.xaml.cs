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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    ///
    /// </summary>
    public class appliance
    {
        private string name;
        private int hours;
        private int minutes;
        private double kwh;

        public appliance()
        {
            name = " ";
            hours = 0;
            minutes = 0;
            kwh = 0.00;
        }

        public appliance(string nm, int hr, int min, double k)
        {
            name = nm;
            hours = hr;
            minutes = min;
            kwh = k;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtTest_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Load_File_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] lines;
            lines = new string[10];
            int count = 0;
            try
            {
                using (StreamReader sr = new StreamReader("test.txt"))
                {
                    String line = sr.ReadToEnd();
                    lines[count] = line;
                }
                txtTest.Text = lines[0];
            }
            catch (Exception ee)
            {
                txtTest.Text = "The file could not be read: " + ee.Message;
            }
            
        }

        private void readFromFile()
        {

        }
    }
}
