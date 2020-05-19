using System.Runtime.InteropServices.ComTypes;

namespace OthelloServer.Models
{
    public class GameboardSquare
    {
        private int index;
        private readonly int row;
        private readonly int col;

        public GameboardSquare(int r, int c, Gameboard board, Tokens p)
        {
            row = r;
            col = c;
            index = (row * board.rows + board.cols);
            Piece = new Gamepiece(Tokens.TokenUnclaimed, GamePieceShapes.SHAPE_UNDEFINED);
        }

        /// <summary>
        /// The index of the gamesquare in the board array.
        /// </summary>
        /// <returns></returns>
        public int Index() { return index; }

        /// <summary>
        /// The gamepiece associated with this square
        /// </summary>
        public Gamepiece Piece { get; set; }
    }
}
