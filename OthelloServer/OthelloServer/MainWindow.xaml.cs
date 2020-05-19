using OthelloServer.Models;
using OthelloServer.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OthelloServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The gameboard view model for this application.
        /// </summary>
        GameboardViewModel gameboardVM { get; set; }
        Gameboard gameboard { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Create the default board
            gameboard = new Gameboard(8, 8);
            
            // Create the view model for the gameboard that we just created
            gameboardVM = new GameboardViewModel(gameboard);

            // Set the datacontext for this view
            this.DataContext = gameboardVM;

        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            //Start the Game
            gameboardVM.StartGame();

            //Draw the area
            DrawGameArea();
        }

        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;
            int nextX = 0; // upper left x-coordinate of game square pixel
            int nextY = 0; // upper left y-coordinate of game square pixel
            int index = 0;
            int rowCounter = 0;
            int colCounter;
            bool nextIsOdd = false;

            // Our gamepieces
            double pieceWidth = (gameboardVM.GameboardVM[index].SquareWidth * 0.8);
            double pieceHeight = (gameboardVM.GameboardVM[index].SquareHeight * 0.8);

            // Compute the offset to center the piece in the game square
            double xOffset = ((int)gameboardVM.GameboardVM[index].SquareWidth - pieceWidth) / 2.0;
            double yOffset = ((int)gameboardVM.GameboardVM[index].SquareHeight - pieceHeight) / 2.0;


            while (!doneDrawingBackground)
            {
                // Our game square
                Rectangle rect = new Rectangle
                {
                    Width = (int)gameboardVM.GameboardVM[index].SquareWidth,
                    Height = (int)gameboardVM.GameboardVM[index].SquareHeight,
                    Fill = Brushes.DarkGreen,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };

                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                // Create our game pieces for the board based on the gameboard model
                Gamepiece piece = new Gamepiece(gameboard.GameBoard[index].Piece.Owner, gameboard.GameBoard[index].Piece.PieceShape);
                GamepieceViewModel pieceVM = new GamepieceViewModel(gameboardVM.GameboardVM[index].PieceVM.Piece, pieceWidth, pieceHeight);
                GameArea.Children.Add(pieceVM.PieceShape);
                Canvas.SetTop(pieceVM.PieceShape, nextY + yOffset);
                Canvas.SetLeft(pieceVM.PieceShape, nextX + xOffset);

                colCounter = index % gameboard.rows;

                nextIsOdd = !nextIsOdd;
                nextX += (int)gameboardVM.GameboardVM[index].SquareWidth;

                // Make the top and bottom border rows blue
                if ((rowCounter == 0) || (rowCounter == gameboard.rows - 1))
                {
                    rect.Fill = Brushes.Blue;
                }

                // Make the left and right border cols red
                if ((colCounter % gameboard.cols == 0) || (colCounter % gameboard.cols == (gameboard.cols - 1)))
                {
                    rect.Fill = Brushes.Red;
                }

                // If we've reached the end of the current
                if (colCounter == gameboard.cols - 1)
                {
                    nextX = 0;
                    nextY += (int)gameboardVM.GameboardVM[index].SquareHeight;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }
                
                index++;

                // If we've reached the last element of the gameboard, then set the flag for done
                if ((rowCounter >= gameboard.rows) || (index >= gameboardVM.GameboardVM.Count))
                    doneDrawingBackground = true;
            }


        }


    }
}
