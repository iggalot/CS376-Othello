using System.Runtime.InteropServices.ComTypes;

namespace OthelloServer.Models
{
    public class GameboardSquare
    {
        private int index;
        private Tokens piece;
        private int row;
        private int col;
        private Gameboard board;

        public GameboardSquare(int r, int c, Gameboard board, Tokens p)
        {
            row = r;
            col = c;
            index = (row * board.rows + board.cols);
            piece = p;

        }

        public int Index() { return index; }

        public Tokens Piece {
            get => piece;
            set => this.piece = value; 
        }
    }
}
