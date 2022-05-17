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
    class WallClass
    {
        #region members
        //properties
        private List<int[]> wallsList { get; set; }
        private PlayWindow ObjectsLocation { get; set; }
        private List<int[]> CreatedLevel { get; set; }
        #endregion

        #region constructor
        public WallClass(PlayWindow objectsLocation)
        {
            ObjectsLocation = objectsLocation;
        }
        #endregion

        #region methods
        //function to generate level and add it to the list variable
        public List<int[]> GenerateLevel(int level)
        {
            CreatedLevel = new List<int[]>();

            switch (level)
            {
                case 0: CreatedLevel = LevelZero(); break;
                case 1: CreatedLevel = LevelOne(); break;
                case 2: CreatedLevel = LevelTwo(); break;
                default: break;
            }

            return CreatedLevel;
        }

        #region levels
        private List<int[]> LevelZero() // co-ordinates of walls for level 1
        {
            wallsList = new List<int[]>();
                                     //X                              Y
            wallsList.Add(new int[1] { 7 });                        //0
            wallsList.Add(new int[5] { 1, 2, 3, 4, 5 });            //1
            wallsList.Add(new int[3] { 2, 4, 8 });                  //2
            wallsList.Add(new int[3] { 1, 4, 8 });                  //3
            wallsList.Add(new int[3] { 1, 3, 8 });                  //4
            wallsList.Add(new int[7] { 0, 3, 4, 6, 7, 8, 9 });      //5
            wallsList.Add(new int[1] { 6 });                        //6
            wallsList.Add(new int[4] { 2, 3, 4, 7 });               //7
            wallsList.Add(new int[1] { 7 });                        //8
            wallsList.Add(new int[6] { 1, 2, 3, 4, 5, 6 });         //9

            ObjectsLocation.CharacterRow = 4;
            ObjectsLocation.CharacterColumn = 4;
            ObjectsLocation.KeyRow = 3;
            ObjectsLocation.KeyColumn = 6;
            ObjectsLocation.ToolboxRow = 9;
            ObjectsLocation.ToolboxColumn = 0;

            return wallsList;
        }

        private List<int[]> LevelOne()
        {
            wallsList = new List<int[]>();

            wallsList.Add(new int[3] { 0, 1, 3 });
            wallsList.Add(new int[2] { 2, 4 });
            wallsList.Add(new int[3] { 5, 7, 8 });
            wallsList.Add(new int[4] { 2, 5, 6, 9 });
            wallsList.Add(new int[0] { });
            wallsList.Add(new int[4] { 2, 4, 7, 9 });
            wallsList.Add(new int[6] { 1, 2, 4, 5, 6, 9 });
            wallsList.Add(new int[1] { 6 });
            wallsList.Add(new int[4] { 2, 3, 4, 6 });
            wallsList.Add(new int[3] { 3, 6, 9 });

            ObjectsLocation.CharacterRow = 7;
            ObjectsLocation.CharacterColumn = 5;
            ObjectsLocation.KeyRow = 2;
            ObjectsLocation.KeyColumn = 3;
            ObjectsLocation.ToolboxRow = 7;
            ObjectsLocation.ToolboxColumn = 7;

            return wallsList;
        }

        private List<int[]> LevelTwo()
        {
            wallsList = new List<int[]>();

            wallsList.Add(new int[8] { 2, 3, 4, 5, 6, 7, 8, 9 });
            wallsList.Add(new int[3] { 0, 2, 7});
            wallsList.Add(new int[2] { 0, 8});
            wallsList.Add(new int[4] { 0, 2, 4, 5});
            wallsList.Add(new int[5] { 0, 4, 7, 8, 9 });
            wallsList.Add(new int[4] { 0, 2, 4, 9 });
            wallsList.Add(new int[3] { 0, 2, 4 });
            wallsList.Add(new int[4] { 0, 5, 7, 9});
            wallsList.Add(new int[5] { 0, 1, 4, 5, 6 });
            wallsList.Add(new int[6] { 0, 1, 3, 4, 5, 6 });

            ObjectsLocation.CharacterRow = 0;
            ObjectsLocation.CharacterColumn = 0;
            ObjectsLocation.KeyRow = 7;
            ObjectsLocation.KeyColumn = 2;
            ObjectsLocation.ToolboxRow = 9;
            ObjectsLocation.ToolboxColumn = 9;

            return wallsList;
        }
        #endregion
        #endregion
    }
}
