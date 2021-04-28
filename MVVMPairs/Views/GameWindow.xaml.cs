using MVVMPairs.Services;
using MVVMPairs.ViewModels;
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

namespace MVVMPairs.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public static bool LoadGame {get; private set;}
        public GameWindow(bool loadGame)
        {
            LoadGame = loadGame;

            InitializeComponent();

        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            Board.SaveData();

            MessageBox.Show("Your configuration has been saved", "Checkers");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
