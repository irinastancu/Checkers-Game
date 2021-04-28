using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace MVVMPairs.Views
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();

            LoadWinners();
        }

        private static string winners="";
        public string Winners
        {
            get => winners;
            set
            {
                winners = value;
                NotifyPropertyChanged("Winners");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadWinners()
        {
            String line;
            try
            {
                
                StreamReader sr = new StreamReader(@"C:\Users\Ina\Desktop\MVVM-DemoGame\MVVMPairs\MVVMPairs\Utils\winners.txt");
               
                line = sr.ReadLine();
                
                while (line != null)
                {

                    winners = winners + " line\n";
                    line = sr.ReadLine();
                }
               
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
