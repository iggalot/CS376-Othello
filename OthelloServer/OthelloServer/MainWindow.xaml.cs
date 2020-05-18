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

            // Create the board
            gameboard = new Gameboard(8, 8);
            
            // Create the view model for the gameboard that we just created
            gameboardVM = new GameboardViewModel(gameboard);

            // Set the datacontext for this view
            this.DataContext = gameboardVM;

        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
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
            bool isBorder;  // a flag to determine if a square is a border element
            bool nextIsOdd = false;

            // Our gamepieces
            double pieceWidth = (gameboardVM.GameboardVM[index].SquareWidth * 0.8);
            double pieceHeight = (gameboardVM.GameboardVM[index].SquareHeight * 0.8);

            // Compute the offset to center the piece in the game square
            double xOffset = ((int)gameboardVM.GameboardVM[index].SquareWidth - pieceWidth) / 2.0;
            double yOffset = ((int)gameboardVM.GameboardVM[index].SquareHeight - pieceHeight) / 2.0;


            while (!doneDrawingBackground)
            {
                isBorder = false;
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

                Brush fillBrush;
                // Our game pieces.
                switch (gameboard.GameBoard[index].Piece)
                {
                    case Tokens.TokenBorder:
                        fillBrush = Brushes.Red;
                        break;
                    case Tokens.TokenP1:
                        fillBrush = Brushes.White;
                        break;
                    case Tokens.TokenP2:
                        fillBrush = Brushes.Black;
                        break;
                    default:
                        fillBrush = Brushes.Blue;
                        break;
                }
                
                Ellipse ellipse = new Ellipse
                {
                    Width = pieceWidth,
                    Height = pieceHeight,
                    Fill = fillBrush
                };
                GameArea.Children.Add(ellipse);
                Canvas.SetTop(ellipse, nextY + yOffset);
                Canvas.SetLeft(ellipse, nextX + xOffset);


                colCounter = index % gameboard.rows;

                nextIsOdd = !nextIsOdd;
                nextX += (int)gameboardVM.GameboardVM[index].SquareWidth;

                // Make the top and bottom border rows blue
                if ((rowCounter == 0) || (rowCounter == gameboard.rows - 1))
                {
                    rect.Fill = Brushes.Blue;
                    isBorder = true;
                }

                // Make the left and right border cols red
                if ((colCounter % gameboard.cols == 0) || (colCounter % gameboard.cols == (gameboard.cols - 1)))
                {
                    rect.Fill = Brushes.Red;
                    isBorder = true;
                }

                // If it's not a border element, create and draw a piece for it
                if(!isBorder)
                { 

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

                // If we've reached the lest element of the gameboard, then set the flag for done
                if ((rowCounter >= gameboard.rows) || (index >= gameboardVM.GameboardVM.Count))
                    doneDrawingBackground = true;
            }


        }


    }
}
