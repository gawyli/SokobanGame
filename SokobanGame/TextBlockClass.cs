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
    class TextBlockClass
    {
        #region members
        //properties
        private TextBlock InstructionBlock { get; set; }
        private TextBlock NumberOfMoves { get; set; }
        #endregion

        #region constructor
        public TextBlockClass()
        {

        }
        #endregion

        #region methods
        public TextBlock InstructionBlk()      //creates instruction block
        {
            //create textblock
            InstructionBlock = new TextBlock();
            InstructionBlock.FontSize = 32;
            InstructionBlock.FontFamily = new FontFamily("Bauhaus 93");
            InstructionBlock.Text = "Use arrow keys to move around the screen";
            InstructionBlock.TextWrapping = TextWrapping.Wrap;
            InstructionBlock.Width = 300;
            InstructionBlock.Foreground = Brushes.White;

            return InstructionBlock;
        }

        public TextBlock NumberOfMovesBlk(int amountOfMoves)    //creates textblock with number of moves
        {
            if (amountOfMoves == 0)     //if number of moves is 0 (beginning of game) do statement below
            {
                NumberOfMoves = new TextBlock();
                NumberOfMoves.Name = "tbl_moves";
                NumberOfMoves.FontSize = 32;
                NumberOfMoves.FontFamily = new FontFamily("Bauhaus 93");
                NumberOfMoves.Text = "Amount of moves: " + "\n" + amountOfMoves;
                NumberOfMoves.Foreground = Brushes.White;
            }
            else        //if number of moves is more than 0 (player is moving) then print below statement
            {
                NumberOfMoves.Text = "Amount of moves: " + "\n" + amountOfMoves;
            }

            return NumberOfMoves;
        }
        #endregion
    }
}
