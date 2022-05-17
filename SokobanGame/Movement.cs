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
    class Movement
    {
        #region members
        //properties
        private GridClass window { get; set; }
        private PopulateGrid populateGrid { get; set; }
        private PlayWindow objectsLocation { get; set; }
        private List<int[]> WallsList { get; set; }
        private CanvasClass UpdateCanvas { get; set; }
        private TextBlockClass CreateTextBlock { get; set; }
        private ButtonClass CreateButton { get; set; }
        private UpdateElementsOnCanvas UpdElementsOnCanvas { get; set; }

        //variables
        private int targetCellRow, targetCellColumn, targetCellRowForKey, targetCellColumnForKey;
        #endregion

        #region constructor
        public Movement(GridClass window, PlayWindow objectsLocation, List<int[]> wallsList, CanvasClass updateCanvas, TextBlockClass createTextBlock, ButtonClass createButton)
        {
            this.window = window;
            this.objectsLocation = objectsLocation;
            WallsList = wallsList;
            UpdateCanvas = updateCanvas;
            CreateTextBlock = createTextBlock;
            CreateButton = createButton;

        }
        #endregion

        #region methods
        //function which pass names of keys to the function of move
        public void MoveCharacter(KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left: Move("left"); break;
                case Key.Up: Move("up"); break;
                case Key.Right: Move("right"); break;
                case Key.Down: Move("down"); break;
                default: break;
            }
        }

        //function which indicate where character must move after press the key
        private void Move(string direction)
        {
            bool isHitWall = false;
            bool isPassLevel = false;
            int i = 0, j = 0;

            switch (direction)
            {
                case "left": i = 0; j = -1; break;
                case "up": i = -1; j = 0; break;
                case "right": i = 0; j = 1; break;
                case "down": i = 1; j = 0; break;
                default: break;
            }

            populateGrid = new(window, objectsLocation);

            //if statment which check if character has still empty field to move. It prevents to jump out of the grid 
            if (((targetCellRow = objectsLocation.CharacterRow + i) < 10) && ((targetCellRow = objectsLocation.CharacterRow + i) >= 0) && ((targetCellColumn = objectsLocation.CharacterColumn + j) < 10) && ((targetCellColumn = objectsLocation.CharacterColumn + j) >= 0))
            {
                //For loop to interate through wall co-ordinate in wall list
                for (int counterX = 0; counterX < 10; counterX++)
                {
                    for (int counterY = 0; counterY < WallsList[counterX].Length; counterY++)
                    {
                        // if statement which check if the next field for the character is a wall, not the empty space 
                        if (targetCellRow == counterX && targetCellColumn == WallsList[counterX][counterY])
                        {
                            isHitWall = true;   //boolean variable, so that we know the next field is a wall and for loop should be stop
                            break;      //break loop as the next field is the wall
                        }
                    }
                }
                // If statement which check if penguin has moved to empty field, not to the space with the wall
                if (!isHitWall)
                {
                    //if statement which check if character wants to move to the field with treasure chest, if not then program move forward
                    if (targetCellRow != objectsLocation.ToolboxRow || targetCellColumn != objectsLocation.ToolboxColumn)
                    {
                        targetCellRowForKey = objectsLocation.KeyRow;   //assign current location (row - x) of key to the target variable for key
                        targetCellColumnForKey = objectsLocation.KeyColumn;     //assign current location (columnt - y) of key to the target variable for key

                        //if statement which check if character co-ordinates are the same as key co-ordinate, if not check else statement on line 122
                        if ((targetCellRow == targetCellRowForKey) && (targetCellColumn == targetCellColumnForKey))
                        {
                            //For loop to interate through wall co-ordinate in wall arrays
                            for (int counterX = 0; counterX < 10; counterX++)
                            {
                                for (int counterY = 0; counterY < WallsList[counterX].Length; counterY++)
                                {
                                    //if statement which check if the key next field is the wall
                                    if ((targetCellRowForKey + i == counterX) && (targetCellColumnForKey + j == WallsList[counterX][counterY]))
                                    {
                                        isHitWall = true;   //if the key's next field is wall then set up it to be true and break the loop
                                        break;
                                    }
                                }
                            }

                            // if statement check if the key hit the wall if not then program move forward
                            if (!isHitWall)
                            {
                                //if statment which check if the key has still empty field to move. It prevents to jump out of the grid 
                                if (((targetCellRowForKey + i) < 10) && ((targetCellRowForKey + i) >= 0) && ((targetCellColumnForKey + j) < 10) && ((targetCellColumnForKey + j) >= 0))
                                {
                                    //if statement which check if the key's next field is the treasure chest
                                    if ((targetCellRowForKey + i) == objectsLocation.ToolboxRow && (targetCellColumnForKey + j) == objectsLocation.ToolboxColumn)
                                    {
                                        targetCellRowForKey += i;       //update row co-ordinate for key by adding i 
                                        targetCellColumnForKey += j;    //update column co-ordinate for key by adding j 
                                        isPassLevel = true;

                                        populateGrid.DrawItems(targetCellRow, targetCellColumn, targetCellRowForKey, targetCellColumnForKey);
                                        MessageBox.Show("You won nothing! ;)");
                                        UpdateElementsOnCanvas(isPassLevel);

                                    }
                                    //if not then update co-ordinates for the key and draw items on the grid
                                    else
                                    {
                                        targetCellRowForKey += i;
                                        targetCellColumnForKey += j;

                                        populateGrid.DrawItems(targetCellRow, targetCellColumn, targetCellRowForKey, targetCellColumnForKey);
                                        UpdateElementsOnCanvas(isPassLevel);
                                    }
                                }
                            }
                        }
                        else    //draw items on the grid
                        {
                            populateGrid.DrawItems(targetCellRow, targetCellColumn, targetCellRowForKey, targetCellColumnForKey);
                            UpdateElementsOnCanvas(isPassLevel);
                        }
                    }
                }
            }
        }

        //function which update textblock and nextbutton during the game is playing by the user
        private void UpdateElementsOnCanvas(bool isPassLevel)
        {
            UpdElementsOnCanvas = new(UpdateCanvas);

            if (!isPassLevel)
            {
                objectsLocation.AmountOfMoves++;
                UpdElementsOnCanvas.UpdateNoMoves(objectsLocation.AmountOfMoves, CreateTextBlock);
            }
            else
            {
                UpdElementsOnCanvas.EnableNextLvButton(CreateButton, isPassLevel);
            }
        }
        #endregion
    }
}
