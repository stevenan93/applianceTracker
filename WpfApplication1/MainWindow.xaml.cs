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
    /// 

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

        public string getName()
        {
            return name;
        }

        public appliance(string nm, int hr, int min, double k)
        {
            name = nm;
            hours = hr;
            minutes = min;
            kwh = k;
        }

        public string applianceToString()
        {
            string output = "Name: " + name;
            output += "\nTime: " + hours + ":" 
                        + minutes + "\nkwH: " + kwh;
            return output;
        }
    }

    public partial class MainWindow : Window
    {
        private appliance[] appArr= new appliance[50];
        private int appCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void displayAllAppliances(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text += System.Environment.NewLine;
            for (int i = 0; i < appCount; i++)
            {
                ResultBlock.Text += System.Environment.NewLine + appArr[i].applianceToString()
                    + System.Environment.NewLine;
            }
        }


        //called from Load_File_Button_Click, makes an array of appliances
        private void makeAppliances(string[] arrIn, int count)
        {
            appCount = count / 4;
            int j = 0; //for the appArray 
            for(int i = 0; i < count; i = i + 4)
            {
                appliance newApp = new appliance(arrIn[i], Convert.ToInt32(arrIn[i + 1]), Convert.ToInt32(arrIn[i + 2]), Convert.ToDouble(arrIn[i + 3]));
                appArr[j] = newApp;
                j++;
            }
        }


        //upon button click, loads data from file into a string array
        private void Load_File_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int counter = 0;
                string line;
                string[] fileArr;
                fileArr = new string[50];

                System.IO.StreamReader file = new System.IO.StreamReader("data.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if(line[0] != '*')
                    {
                        fileArr[counter] = line;
                        ++counter;
                    }
                }
                if(counter % 4 == 0)
                {
                    ResultBlock.Text = Convert.ToString(counter / 4) + " appliances registered.";
                }
                else
                {
                    ResultBlock.Text = "Corrupted file, or irregular number of lines in file. Each appliance should have 4 fields.";
                }

                makeAppliances(fileArr, counter);
                file.Close();
            }
            catch (IOException)
            {
                ResultBlock.Text = "File not found";
            }
        }
    }
}
