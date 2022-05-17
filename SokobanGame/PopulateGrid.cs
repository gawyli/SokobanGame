using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SokobanGame
{
    class PopulateGrid
    {
        #region members
        //properties
        private GridClass Window { get; set; }
        private PlayWindow ObjectsLocation { get; set; }

        //variables
        public int sizeOfGridRow = 10;
        #endregion

        #region constructors
        public PopulateGrid(GridClass window, PlayWindow objectsLocation)
        {
            Window = window;
            ObjectsLocation = objectsLocation;
        }
        #endregion

        #region methods

        public void DrawContents(string uriLocation, int row, int column)       //add images to grid
        {
            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) };   //create instance for image and assign img source
            Window.AppGrid.Children.Add(img);       //add the image to the grid
            Grid.SetRow(img, row);      //set image in specific row
            Grid.SetColumn(img, column);    //set image in specific column
        }

        //function which iterate throught each cell and draw image by using DrawContents function
        public void DrawGrid()
        {
            for (int x = 0; x < sizeOfGridRow; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    DrawContents("images\\floor.jpg", x, y);    //fill all empty field by blank img
                }
            }

            DrawContents("images\\character.png", ObjectsLocation.CharacterRow, ObjectsLocation.CharacterColumn);  //set up image for character on the grid
            DrawContents("images\\key.png", ObjectsLocation.KeyRow, ObjectsLocation.KeyColumn); //set up key on the grid
            DrawContents("images\\treasure_chest.png", ObjectsLocation.ToolboxRow, ObjectsLocation.ToolboxColumn); //set up image for toolbox on the grid

        }

        //function for draw wall's images on the grid
        public void DrawWalls(List<int[]> wallsList)
        {
            try   // error handler which allows to the user continues play when last level is reached
            {
                for (int counterX = 0; counterX < sizeOfGridRow; counterX++)
                {
                    for (int counterY = 0; counterY < wallsList[counterX].Length; counterY++)
                    {
                        DrawContents("Images\\wall.png", counterX, wallsList[counterX][counterY]);
                    }
                }
            }
            catch
            {

            }
        }

        public void DrawItems(int targetCellRow, int targetCellColumn, int targetCellRowForKey, int targetCellColumnForKey)
        {
            //update the original cell where the key was to be a floor
            DrawContents("Images\\floor.jpg", targetCellRow, targetCellColumn);

            // draw a character in the new co-ordinates
            DrawContents("Images\\character.png", targetCellRow, targetCellColumn);

            //update the original cell where the character was to be a floor cell
            DrawContents("Images\\floor.jpg", ObjectsLocation.CharacterRow, ObjectsLocation.CharacterColumn);

            //if statement which checks if the key target - coordiante and toolbox coordinate are the same
            if (targetCellRowForKey == ObjectsLocation.ToolboxRow && targetCellColumnForKey == ObjectsLocation.ToolboxColumn)
            {
                //update the original cell where the key was to be a blank cell
                DrawContents("Images\\floor.jpg", targetCellRow, targetCellColumn);

                // draw a character in the new co-ordinates
                DrawContents("Images\\character.png", targetCellRow, targetCellColumn);
            }
            else
            {
                //draw a key in new coordinates
                DrawContents("Images\\key.png", targetCellRowForKey, targetCellColumnForKey);
            }


            //update the objects location to the new co-ordinates
            UpdateObjectsLocations(targetCellRow, targetCellColumn, targetCellRowForKey, targetCellColumnForKey);
        }

        private void UpdateObjectsLocations(int targetCellRow, int targetCellColumn, int targetCellRowForKey, int targetCellColumnForKey)
        {
            ObjectsLocation.CharacterRow = targetCellRow;
            ObjectsLocation.CharacterColumn = targetCellColumn;
            ObjectsLocation.KeyRow = targetCellRowForKey;
            ObjectsLocation.KeyColumn = targetCellColumnForKey;
        }
        #endregion
    }
}
