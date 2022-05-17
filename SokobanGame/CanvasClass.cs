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
    class CanvasClass
    {
        #region members
        //properites
        public Canvas WindowCanvas { get; set; }   //automatic propierties
        private UpdateElementsOnCanvas UpdateElementsOnCanvas { get; set; }

        //variables
        private bool isPassLevel = false;
        private int amountOfMoves = 0;
        #endregion

        public CanvasClass(int amountOfMoves)
        {
            this.amountOfMoves = amountOfMoves;
        }

        #region methods
        public Canvas arrangeOnCanvas(TextBlockClass createTextBlock, ButtonClass createButton, Border appGrid)      //fits all elements on the canvas
        {
            string mode = "reset";

            //Create Text blocks
            TextBlock instructionBlock = createTextBlock.InstructionBlk();

            //Create Buttons
            Button resetButton = createButton.BtnStyle(mode);
            resetButton.Content = "Reset game";

            WindowCanvas = new Canvas();
            //add elements to the canvas
            WindowCanvas.Children.Add(instructionBlock);    //textblock
            WindowCanvas.Children.Add(resetButton);        //reset button
            WindowCanvas.Children.Add(appGrid);          //border which contains grid

            //set up elements at the specific position
            Canvas.SetLeft(instructionBlock, 50);
            Canvas.SetTop(instructionBlock, 50);

            Canvas.SetLeft(resetButton, 50);
            Canvas.SetTop(resetButton, 370);


            UpdateElementsOnCanvas = new(this); //instance for update elements on canvas allows us to update textblock and button during the game is playing

            UpdateElementsOnCanvas.UpdateNoMoves(amountOfMoves, createTextBlock);   //creates textblock with no of moves
            UpdateElementsOnCanvas.EnableNextLvButton(createButton, isPassLevel);   //creates button for next level


            return WindowCanvas;
        }
        #endregion
    }
}
