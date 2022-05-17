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
    class UpdateElementsOnCanvas
    {
        #region members
        //properties
        private CanvasClass UpdateCanvas { get; set; }
        private TextBlock NumberOfMoves { get; set; }
        private Button NextLvButton { get; set; }
        #endregion

        #region constructor
        public UpdateElementsOnCanvas(CanvasClass updateCanvas)
        {
            UpdateCanvas = updateCanvas;
        }
        #endregion

        #region methods

        //function which update textblock with number of moves
        public void UpdateNoMoves(int amountOfMoves, TextBlockClass createTextBlock)
        {

            NumberOfMoves = createTextBlock.NumberOfMovesBlk(amountOfMoves);
            UpdateCanvas.WindowCanvas.Children.Remove(NumberOfMoves);
            UpdateCanvas.WindowCanvas.Children.Add(NumberOfMoves);

            Canvas.SetLeft(NumberOfMoves, 50);
            Canvas.SetTop(NumberOfMoves, 220);


        }

        //function which change isEnable of button
        public void EnableNextLvButton(ButtonClass createNextLvButton, bool isPassLevel)
        {
            string mode = "level";

            NextLvButton = createNextLvButton.BtnStyle(mode);
            UpdateCanvas.WindowCanvas.Children.Remove(NextLvButton);
            NextLvButton.Content = "Next level";
            
            if (isPassLevel)
            {
                NextLvButton.IsEnabled = true;
            }
            else
            {
                NextLvButton.IsEnabled = false;
            }

            UpdateCanvas.WindowCanvas.Children.Add(NextLvButton);

            Canvas.SetLeft(NextLvButton, 50);
            Canvas.SetTop(NextLvButton, 430);
        }
        #endregion
    }
}
