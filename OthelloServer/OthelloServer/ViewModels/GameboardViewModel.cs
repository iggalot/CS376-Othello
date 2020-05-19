using OthelloServer.Models;
using System.Collections.ObjectModel;

namespace OthelloServer.ViewModels
{
    /// <summary>
    /// A view model associated with our gameboard model
    /// </summary>
    public class GameboardViewModel
    {
        #region Private Properties
        // The default dimensions of the squares on our gameboard.
        private readonly double squareWidth = 30;
        private readonly double squareHeight = 30;
        #endregion

        #region Public Properties
        /// <summary>
        /// Default width of a gameboard square
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Default height of a gameboard square
        /// </summary>
        public double Height { get; }

        // Our collecction of GameboardVM
        public ObservableCollection<GameboardSquareViewModel> GameboardVM { get; set; }

        // The Gameboard model associated with this view model
        public Gameboard GameboardModel { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The model associated with the viewmodel</param>
        public GameboardViewModel(Gameboard model)
        {
            GameboardModel = model;
            GameboardVM = new ObservableCollection<GameboardSquareViewModel>();

            for(int i=0; i<model.size;i++)
            {
                GameboardSquareViewModel vm = new GameboardSquareViewModel(model.GameBoard[i], i, squareWidth, squareHeight);
                GameboardVM.Add(vm);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a piece to the associated gameboard square's
        /// model and view model.
        /// </summary>
        /// <param name="index">the square index to add the piece</param>
        /// <param name="piece">the piece to add</param>
        public void AddPiece(int index, Gamepiece piece)
        {
            GameboardVM[index].AddPiece(piece);            
        }

        /// <summary>
        /// Removes the piece in the associated gameboard square's
        /// model and view model.
        /// </summary>
        /// <param name="index">the square index to remove the piece</param>
        public void RemovePiece(int index)
        {
            GameboardVM[index].RemovePiece();
        }

        /// <summary>
        /// Return the contents of the gameboard as a string, using the Token enum values
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            string str = "";

            for (int i = 0; i < GameboardModel.rows; i++)
            {
                for (int j = 0; j < GameboardModel.cols; j++)
                {
                    int index = i * GameboardModel.cols + j;
                    str += ((int)GameboardModel.GameBoard[index].Piece.Owner).ToString();
                }
                str += "\n";
            }

            return str;
        }

        /// <summary>
        /// Sets up the game board, with the initial configuration
        /// </summary>
        public void StartGame()
        {
            //Initial board setup
            // get middle index
            int mid_row = GameboardModel.rows / 2;
            int mid_col = GameboardModel.cols / 2;
            int mid_index = (mid_row - 1) * GameboardModel.cols + mid_col - 1;

            // Add the top of the middle rows
            AddPiece(mid_index, new Gamepiece(Tokens.TokenP1, GamePieceShapes.SHAPE_CIRCLE));
            AddPiece((mid_index + 1), new Gamepiece(Tokens.TokenP2, GamePieceShapes.SHAPE_CIRCLE));

            // Add the bottom of the middle rows
            AddPiece((mid_index + GameboardModel.cols), new Gamepiece(Tokens.TokenP2, GamePieceShapes.SHAPE_CIRCLE));
            AddPiece((mid_index + GameboardModel.cols + 1), new Gamepiece(Tokens.TokenP1, GamePieceShapes.SHAPE_CIRCLE));

            //RemovePiece(mid_index + cols + 1);
            //AddPiece((mid_index + cols + 2), new Gamepiece(Tokens.TokenP1, GamePieceShapes.SHAPE_SQUARE));
        }
        #endregion
    }
}
