using OthelloServer.Models;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OthelloServer.ViewModels
{
    /// <summary>
    /// A view model associated with a gamepiece
    /// </summary>
    public class GamepieceViewModel
    {
        #region Public Properties
        public Gamepiece Piece { get; set; }

        // The shape of our piece - singleton.
        public Shape PieceShape { get; set; }

        // The width of our piece
        public double GetWidth { get; set; }

        // The height of our piece
        public double GetHeight { get; set; }

        // The fill-color of the piece
        public Brush PieceColor { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">The associated gamepiece model</param>
        /// <param name="width">The width of the gamepiece</param>
        /// <param name="height">The height of the gamepiece</param>
        public GamepieceViewModel(Gamepiece model, double width, double height)
        {
            GetWidth = width;
            GetHeight = height;
            Piece = model;
            PieceColor = GetColor(model.Owner);
            PieceShape = GetShape(model.PieceShape);
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///  A function to return the Brush color of a piece 
        ///  based on the owner of the piece
        /// </summary>
        /// <param name="owner">Token enum of the owner of the piece</param>
        /// <returns></returns>
        public Brush GetColor(Tokens owner)
        {
            switch (owner)
            {
                case Tokens.TokenBorder:
                    return Brushes.Red;
                case Tokens.TokenP1:
                    return Brushes.White;
                case Tokens.TokenP2:
                    return Brushes.Black;
                default:
                    return Brushes.Blue;
            }
        }

        /// <summary>
        /// Retrieves a Shape object based on an Enum value
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public Shape GetShape(GamePieceShapes shapes)
        {
            Shape shape;
            switch (shapes)
            {
                case GamePieceShapes.SHAPE_CIRCLE:
                    shape = new Ellipse
                    {
                        Width = GetWidth,
                        Height = GetHeight,
                        Fill = GetColor(Piece.Owner)
                    };
                    break;
                case GamePieceShapes.SHAPE_SQUARE:
                    shape = new Rectangle
                    {
                        Width = GetWidth,
                        Height = GetHeight,
                        Fill = GetColor(Piece.Owner)
                    };
                    break;
                default:
                    shape = new Ellipse
                    {
                        Width = 10,
                        Height = 10,
                        Fill = Brushes.Gray
                    };
                    break;
            }
            return shape;
        }
        #endregion
    }
}
