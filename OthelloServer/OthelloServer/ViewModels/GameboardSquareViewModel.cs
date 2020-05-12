using OthelloServer.Models;
using System;

namespace OthelloServer.ViewModels
{
    public class GameboardSquareViewModel
    {
        private int index;
        private GameboardSquare model;
        private double square_ht;
        private double square_width;

        public GameboardSquareViewModel(GameboardSquare m, int i, double w, double h)
        {
            index = i;
            model = m;
            square_ht = h;
            square_width = w;
        }

        public int Index { get => index; set => index=value; }

        public double SquareHeight { get => square_ht; set => square_ht = value; }
        public double SquareWidth { get => square_width; set => square_width = value; }
    }
}
