﻿using System.Windows;

namespace OthelloServer.Models
{
    public class Gameboard
    {
        public int rows;
        public int cols;
        public int size;
        public GameboardSquare[] GameBoard;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="r">Number of horizontal squares on the gameboard</param>
        /// <param name="c">Number of vertical squares on the gameboard</param>
        public Gameboard(int r, int c)
        {
            if (r < 2 || c < 2)
            {
                MessageBox.Show("Board is too small.  Must be larger than 2x2");
                return;
            }

            rows = r + 2;
            cols = c + 2;
            size = rows * cols;

            // initialize the array
            GameBoard = new GameboardSquare[rows * cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // create a gameboard square
                    GameboardSquare square = new GameboardSquare(i, j, this, Tokens.TokenUnclaimed);

                    int index = i * cols + j;
                    // Add a horizontal border to top and bottom
                    if ((j == 0) || (j == cols - 1))
                    {

                        square.Piece = Tokens.TokenBorder;
                    }
                    // Add a vertical border to left and right
                    else if ((i == 0) || (i == rows - 1))
                    {
                        square.Piece = Tokens.TokenBorder;
                    }
                    else
                        square.Piece = Tokens.TokenUnclaimed;

                    // add the square to the collection
                    GameBoard[index] = square;

                    //MessageBox.Show("i: " + i.ToString() + "   j: " + j.ToString() + "   index: " + index.ToString());
                }
            }
        }

        /// <summary>
        /// Return the contents of the gameboard as a string, using the Token enum values
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            string str = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int index = i * cols + j;
                    str += ((int)GameBoard[index].Piece).ToString();
                }
                str += "\n";
            }

            return str;
        }

        /// <summary>
        /// Return the size of the board (including border squares)
        /// </summary>
        /// <returns></returns>
        public int Size() { return size; }
    }
}