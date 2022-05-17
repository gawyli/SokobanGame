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

namespace SokobanGame
{
    /// <summary>
    /// Integrated class for MenuGame.xaml
    /// </summary>
    public partial class MenuGame : Window
    {
        public MenuGame()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Btn_startGame.Focus();
        }
        
        //Start Game function
        private void Btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            int level = 0;  //first level in the game

            Window playWindow = new PlayWindow("Sokoban Game", level);      //Function pass parameters such as title of window and starting level
            playWindow.Show();
            Close();
        }

        //Exit game function
        private void Btn_exitGame_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
