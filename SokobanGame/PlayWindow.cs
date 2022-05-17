using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SokobanGame
{
    class PlayWindow : Window
    {
        #region members
        //properties
        public Movement Mover { get; set; }
        public int CharacterRow { get; set; }
        public int CharacterColumn { get; set; }
        public int KeyRow { get; set; }
        public int KeyColumn { get; set; }
        public int ToolboxRow { get; set; }
        public int ToolboxColumn { get; set; }
        public int AmountOfMoves { get; set; }

        //variables
        public int level;
        private string bg = "images\\bg-warehouse.jpg";     //source of background image
        #endregion

        #region constructor
        public PlayWindow(string windowName, int level)
        {
            Title = windowName;
            this.level = level;
            InitializeWindow(level);
        }
        #endregion

        #region methods
        private void WindowSettings()   //function which set up all parameters of new window
        {
            ImageBrush myBackground = new ImageBrush();
            myBackground.ImageSource = new BitmapImage(new Uri(bg, UriKind.Relative));


            WindowStartupLocation = WindowStartupLocation.CenterScreen;    //command to centralise the window on the screen
            Width = 900;
            Height = 600;
            Background = myBackground;
            ResizeMode = ResizeMode.NoResize;
        }

        private void InitializeWindow(int level)     //creates and fits window elements
        {

            WindowSettings();
            
            #region create elements from classes
            //Walls
            WallClass walls = new WallClass(this);
            List<int[]> wallsList = walls.GenerateLevel(level);

            //Textblock
            TextBlockClass createTextBlock = new();      //create new textblock

            //return button
            ButtonClass createButton = new ButtonClass(this);   //create new button

            //grid 
            GridClass gridBorder = new GridClass(this, wallsList);
            Border appGrid = gridBorder.CreateGrid();

            //canvas
            CanvasClass windowCanvas = new(AmountOfMoves);
            #endregion

            appGrid.Focus();     //The application automatically select grid, so that user can use keys to move the character

            
            SetupPageEvent();   //Assign character key down handler to the content

            //assign created canvas to this window
            Content = windowCanvas.arrangeOnCanvas(createTextBlock, createButton, appGrid);

            //object movement for character movement
            Mover = new Movement(gridBorder, this, wallsList, windowCanvas, createTextBlock, createButton);
        }

        //event handler for pressed keys on the keyboard by the user
        protected void CharacterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            Mover.MoveCharacter(e);       //assign mover object from MainAppPage and use function MovePenguin located in Movement class. Pass parameter e (user input)

        }

        //assign event handler to the KeyDown function for PlayWindow
        public void SetupPageEvent()
        {
            KeyDown += CharacterLocation_KeyDown;
        }
        #endregion
    }
}
