using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SokobanGame
{
    class ButtonClass
    {
        #region members
        //properties
        private Button NewButton { get; set; }
        private PlayWindow WindowApp { get; set; }
        #endregion

        #region constructors
        public ButtonClass(PlayWindow windowApp)
        {
            WindowApp = windowApp;
        }
        #endregion

        #region methods
        public Button BtnStyle(string mode)      //creates button with passed parameter
        {
            //create return button
            NewButton = new Button();
            NewButton.Height = 49;
            NewButton.Width = 200;
            NewButton.FontSize = 24;
            NewButton.FontFamily = new FontFamily("Bauhaus 93");
            NewButton.Focusable = false;
            
            NewButton.Background = Brushes.DarkSlateGray;
            NewButton.Foreground = Brushes.White;
            //NewButton.Content = "Reset the game";

            SetupPageEvent(mode);   //assign approperaciate event handler as the passed parameter indicate

            return NewButton;
        }
        
        //function which assign specific event handler to approperiate button
        public void SetupPageEvent(string mode)
        {
            switch(mode)
            {
                case "reset": NewButton.Click += ResetButton_Click; break;
                case "level": NewButton.Click += NextLvButton_Click; break;
                default: break;
            }
        }

        //event handler for reset button
        protected void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow resetWindow = new PlayWindow(WindowApp.Title, WindowApp.level);
            resetWindow.Show();
            WindowApp.Close();
        }

        //event handler for next level button
        protected void NextLvButton_Click(object sender, RoutedEventArgs e)
        {
            WindowApp.level++;  //each time when button pressed add one to the variable level

            //if statement which check if last level has been reached
            if (WindowApp.level < 3)
            {
                PlayWindow nextLvWindow = new PlayWindow(WindowApp.Title, WindowApp.level);
                nextLvWindow.Show();
                WindowApp.Close();
            }
            else
            {
                MessageBox.Show("It was last level, thank you for playing! See you soon!");

                Window menuWindow = new MenuGame();
                menuWindow.Show();
                WindowApp.Close();
            }

        }
        #endregion
    }
}
