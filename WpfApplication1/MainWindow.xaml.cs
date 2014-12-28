﻿using System;
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
            output += "\nHours: " + hours + "\nMinutes: " 
                        + minutes + "\nkwH: " + kwh;
            return output;
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
                if (counter != 0)
                {
                    int n = 0;
                    //ResultBlock.Text = fileArr[0];
                    appliance appIn = new appliance(fileArr[n], Convert.ToInt32(fileArr[n + 1]), Convert.ToInt32(fileArr[n + 2]), Convert.ToDouble(fileArr[n + 3]));
                    //ResultBlock.Text = appIn.applianceToString();
                    //ResultBlock.Text = Convert.ToString(counter) ;
                }
                else
                {
                    ResultBlock.Text = "Empty file?";
                }
                    
                file.Close();
            }
            catch (IOException)
            {
                ResultBlock.Text = "File not found";
            }
        }

    }
}
