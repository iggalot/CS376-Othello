using OthelloServer.Models;

namespace OthelloServer.ViewModels
{
    /// <summary>
    /// A view model associated with a gamesquare model
    /// </summary>
    public class GameboardSquareViewModel
    {
        #region Private Properties
        private int index;
        private double square_ht;
        private double square_width;
        #endregion

        #region Public Properties
        /// <summary>
        /// The model associated with this view model
        /// </summary>
        public GameboardSquare Model { get; set; }

        /// <summary>
        /// The gamepiece view model associated with this square
        /// </summary>
        public GamepieceViewModel PieceVM { get; set; }

        /// <summary>
        /// Returns the index of this viewmodekl
        /// </summary>
        public int Index { get => index; set => index = value; }

        /// <summary>
        /// Getter for the height of this square
        /// </summary>
        public double SquareHeight { get => square_ht; set => square_ht = value; }
        /// <summary>
        /// Getter for the  width of this square
        /// </summary>
        public double SquareWidth { get => square_width; set => square_width = value; }

        #endregion

        #region Constructors
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
            Model = m;
            square_ht = h;
            square_width = w;
            PieceVM = new GamepieceViewModel(m.Piece, square_ht, square_width);
        }

        #endregion






        #region Public Methods
        /// <summary>
        /// Adds a gamepiece to this square
        /// </summary>
        /// <param name="piece">The gamepiece to be added</param>
        public void AddPiece(Gamepiece piece)
        {
            UpdatePieceVM(piece);
       }

        /// <summary>
        /// Removes the piece associated with this square
        /// and updates the related viewmodel
        /// </summary>
        public void RemovePiece()
        {
            UpdatePieceVM(new Gamepiece(Tokens.TokenUnclaimed, GamePieceShapes.SHAPE_UNDEFINED));
        }

        /// <summary>
        /// Update the model and viewmodel for the pieces
        /// related to this square
        /// </summary>
        /// <param name="piece"></param>
        private void UpdatePieceVM(Gamepiece piece)
        {
            Model.Piece = piece;
            PieceVM = new GamepieceViewModel(piece, square_ht, square_width);
        }
        #endregion
    }
}
