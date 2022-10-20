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
using System.IO;

namespace HemsidegeneratorWPF
{
    public partial class MainWindow : Window
    {
        static List<string> messages = new List<string>();
        static List<string> techniques = new List<string>();
        public static string color = "black";

        StyledWebsiteGenerator website = new StyledWebsiteGenerator(".NET 22",color, messages, techniques);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            htmlText.Text = website.PrintPage();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = fileNameBox.Text + ".html";
            File.WriteAllText(fileName, htmlText.Text);
            fileNameBox.Clear();
            htmlText.Clear();

        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            string fileToOpen = fileToLoad.Text + ".html";
            var lines = File.ReadAllLines(fileToOpen);
            foreach (var line in lines)
            {
                htmlText.Text += line;
            }
            fileToLoad.Clear();

        }

        private void addMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = meddelandenBox.Text;
            messages.Add(message);
            meddelandenBox.Clear();
            addedMessagesLabel.Content += message + "\n";
        }

        private void addKurser_Click(object sender, RoutedEventArgs e)
        {
            string technique = kurserBox.Text;
            techniques.Add(technique);
            kurserBox.Clear();
            addedTechniquesLabel.Content += technique + "\n";

        }

        private void blueButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "blue";
            
        }

        private void loadPage_Click(object sender, RoutedEventArgs e)
        {
            
            DisplayPageLabel.Text = website.PrintPage();
        }

        private void redButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "red";
        }

        private void greenButton_Checked(object sender, RoutedEventArgs e)
        {
            color = "green";
        }
    }
}
