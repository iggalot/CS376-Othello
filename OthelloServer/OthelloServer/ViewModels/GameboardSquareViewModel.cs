using OthelloServer.Models;
using System;
using System.Windows;

namespace OthelloServer.ViewModels
{
    public class GameboardSquareViewModel
    {
        private int index;
        private GameboardSquare model;
        private double square_ht;
        private double square_width;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">The gameboard square model associated with this view model</param>
        /// <param name="i">Index of the square on the gameboard</param>
        /// <param name="w">Width of the square in the UI</param>
        /// <param name="h">Height of the square in the UI</param>
        public GameboardSquareViewModel(GameboardSquare m, int i, double w, double h)
        {
            index = i;
            model = m;
            square_ht = h;
            square_width = w;
        }

        /// <summary>
        /// Returns the index of this viewmodekl
        /// </summary>
        public int Index { get => index; set => index=value; }

        /// <summary>
        /// Getter for the height of this square
        /// </summary>
        public double SquareHeight { get => square_ht; set => square_ht = value; }
        /// <summary>
        /// Getter for the  width of this square
        /// </summary>
        public double SquareWidth { get => square_width; set => square_width = value; }


    }
}
