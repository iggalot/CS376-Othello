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

            MessageBox.Show(gameboard.Display());

            //Initial board setup
            // get middle index
            int mid_row = gameboard.rows / 2;
            int mid_col = gameboard.cols / 2;
            int mid_index = (mid_row-1) * gameboard.cols + mid_col -1;

            // Add the top of the middle rows
            gameboard.GameBoard[mid_index].Piece = Tokens.TokenP1;
            gameboard.GameBoard[mid_index + 1].Piece = Tokens.TokenP2;

            // Add the bottom of the middle rows
            gameboard.GameBoard[mid_index + gameboard.cols].Piece = Tokens.TokenP2;
            gameboard.GameBoard[mid_index + gameboard.cols+1].Piece = Tokens.TokenP1;
            MessageBox.Show(gameboard.Display());

            // set the datacontext for this view
            this.DataContext = gameboardVM;

        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            DrawGameArea();
        }

        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;
            int nextX = 0;
            int nextY = 0;
            int index = 0;
            int rowCounter = 0;
            int colCounter = 0;
            bool nextIsOdd = false;

            // The square 0 of the 
            bool firstSquare = true;

            while(!doneDrawingBackground)
            {
                Rectangle rect = new Rectangle
                {
                    Width = (int)gameboardVM.GameboardVM[index].SquareWidth,
                    Height = (int)gameboardVM.GameboardVM[index].SquareHeight,
                    Fill = nextIsOdd ? Brushes.DarkGreen : Brushes.LightGreen
                };

                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                colCounter = index % gameboard.rows;

                nextIsOdd = !nextIsOdd;
                nextX += (int)gameboardVM.GameboardVM[index].SquareWidth;

                // Make the top and bottom border rows blue
                if ((rowCounter == 0) || (rowCounter == gameboard.rows - 1))
                {
                    rect.Fill = Brushes.Blue;     
                }

                // Make the left and right border cols red
                if((colCounter % gameboard.cols == 0) || (colCounter % gameboard.cols == (gameboard.cols - 1)))
                {
                    rect.Fill = Brushes.Red;
                }

                // If we've reached the end of the current
                if(colCounter == gameboard.cols - 1)
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
