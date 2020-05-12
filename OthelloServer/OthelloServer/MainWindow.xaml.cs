using System.Windows;
using System.Windows.Controls.Primitives;

namespace OthelloServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // An enum for each of the players
        public enum Players
        {
            Player0 = 0,
            Plater1 = 1
        }

        // An enum for the owner's token of a square
        public enum Tokens
        {
            TokenBorder = 0,
            TokenP1 = 1,
            TokenP2 = 2,
            TokenUnclaimed = 3
        }

        public class Board
        {
            public int rows;
            public int cols;
            public int size;
            public Tokens[] GameBoard;

            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name="r">Number of horizontal squares on the gameboard</param>
            /// <param name="c">Number of vertical squares on the gameboard</param>
            public Board(int r, int c)
            {
                if (r < 2 || c < 2)
                {
                    MessageBox.Show("Board is too small.  Must be larger than 2x2");
                    return;
                }

                rows = r+2;
                cols = c+2;
                size = rows * cols;

                // initialize the array
                GameBoard = new Tokens[rows * cols];

                for(int i=0; i < rows; i++)
                {
                    for(int j=0; j< cols; j++)
                    {
                        int index = i * cols + j;
                        // Add a horizontal border to top and bottom
                        if ((j==0) || (j==cols-1))
                        {
                            GameBoard[index] = Tokens.TokenBorder;
                        }
                        // Add a vertical border to left and right
                        else if ((i == 0) || (i == rows-1))
                        {
                            GameBoard[index] = Tokens.TokenBorder;
                        }
                        else
                            GameBoard[index] = Tokens.TokenUnclaimed;
                       
                        //MessageBox.Show("i: " + i.ToString() + "   j: " + j.ToString() + "   index: " + index.ToString());
                    }
                }
            }

            /// <summary>
            /// Return the contents of the gameboard as a string, using the Token enum values
            /// </summary>
            /// <returns></returns>
            public string Display()
            {
                string str = "";

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int index = i * cols + j;
                        str += ((int)GameBoard[index]).ToString();
                    }
                    str += "\n";
                }

                return str;
            }

            /// <summary>
            /// Return the size of the board (including border squares)
            /// </summary>
            /// <returns></returns>
            public int Size() { return size; }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Create the board
            Board board = new Board(8, 8);
            MessageBox.Show(board.Display());

            //Initial board setup
            // get middle index
            int mid_row = board.rows / 2;
            int mid_col = board.cols / 2;
            int mid_index = (mid_row-1) * board.cols + mid_col -1;

            // Add the top of the middle rows
            board.GameBoard[mid_index] = Tokens.TokenP1;
            board.GameBoard[mid_index + 1] = Tokens.TokenP2;

            // Add the bottom of the middle rows
            board.GameBoard[mid_index + board.cols] = Tokens.TokenP2;
            board.GameBoard[mid_index + board.cols+1] = Tokens.TokenP1;
            MessageBox.Show(board.Display());
        }
    }
}
