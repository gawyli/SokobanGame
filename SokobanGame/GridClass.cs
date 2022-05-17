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
    class GridClass
    {
        #region members
        //properties
        private Border GridBorder { get; set; }
        public Grid AppGrid { get; set; }
        private PopulateGrid PopulateGrid { get; set; }
        private PlayWindow Window { get; set; }
        private List<int[]> WallsList { get; set; }
        #endregion

        #region constructors
        public GridClass(PlayWindow window, List<int[]> wallsList)
        {
            Window = window;
            WallsList = wallsList;
        }
        #endregion

        #region methods
        public Border CreateGrid()       //create grid
        {
            //Border which will be contains appGrid
            GridBorder = new Border();
            GridBorder.BorderThickness = new Thickness(2);
            GridBorder.BorderBrush = Brushes.Black;
            GridBorder.Margin = new (360, 30, 0, 0);

            //appGrid
            AppGrid = new Grid();
            AppGrid.Width = AppGrid.Height = 500;
            AppGrid.HorizontalAlignment = HorizontalAlignment.Left;
            AppGrid.VerticalAlignment = VerticalAlignment.Top;
            AppGrid.Focusable = true;

            //create columns and row on the grid
            for (int i = 0; i < 10; i++)
            {
                AppGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 10; i++)
            {
                AppGrid.RowDefinitions.Add(new RowDefinition());
            }

            //add appGrid to boarder
            GridBorder.Child = AppGrid;

            //populateGrid with images
            PopulateGrid = new PopulateGrid(this, Window);
            PopulateGrid.DrawGrid();
            PopulateGrid.DrawWalls(WallsList);

            return GridBorder;
        }
        #endregion
    }
}
