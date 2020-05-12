using OthelloServer.Models;
using OthelloServer.ViewModels;
using System.Windows;

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
        GameboardViewModel gameboard { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            // Create the board
            Gameboard board = new Gameboard(8, 8);
            MessageBox.Show(board.Display());

            //Initial board setup
            // get middle index
            int mid_row = board.rows / 2;
            int mid_col = board.cols / 2;
            int mid_index = (mid_row-1) * board.cols + mid_col -1;

            // Add the top of the middle rows
            board.GameBoard[mid_index].Piece = Tokens.TokenP1;
            board.GameBoard[mid_index + 1].Piece = Tokens.TokenP2;

            // Add the bottom of the middle rows
            board.GameBoard[mid_index + board.cols].Piece = Tokens.TokenP2;
            board.GameBoard[mid_index + board.cols+1].Piece = Tokens.TokenP1;
            MessageBox.Show(board.Display());

            // set the datacontext for this view
            this.DataContext = new GameboardViewModel(board);

        }
    }
}
