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

namespace MVVMPairs.Views
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

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //Initialize new Game

            GameWindow g = new GameWindow(false);
            g.Show();
            this.Close();
            //open the game window
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow g = new GameWindow(true);
            g.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutGameWindow a = new AboutGameWindow();
            a.Show();
            this.Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow h = new HelpWindow();
            h.Show();
            this.Close();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow s = new StatisticsWindow();
            s.Show();
            this.Close();
        }
    }
}
