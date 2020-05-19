using System.Windows;

namespace OthelloServer.Models
{
    /// <summary>
    /// A class for the information regarding the game piece.
    /// Inherits from UIElement for drawing purposes of storing
    /// the shape of the gamepiece.
    /// </summary>
    public class Gamepiece : UIElement
    {

        /// <summary>
        /// The enum of the piece shape for this model
        /// </summary>
        public GamePieceShapes PieceShape { get; set; }

        /// <summary>
        /// The enum of the owner for this model
        /// </summary>
        public Tokens Owner { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="owner">Enum for the owner of the game piece</param>
        /// <param name="shape">Enum for the shape of the game piece</param>
        public Gamepiece(Tokens owner, GamePieceShapes shape)
        {
            Owner = owner;
            PieceShape = shape;
        }
    }
}
