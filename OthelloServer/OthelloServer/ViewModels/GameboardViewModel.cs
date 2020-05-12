using OthelloServer.Models;
using System.Collections.ObjectModel;

namespace OthelloServer.ViewModels
{
    public class GameboardViewModel
    {
        // Our collecction of GameboardVM
        public ObservableCollection<GameboardSquareViewModel> GameboardVM { get; set; }

        private double squareWidth = 25;
        private double squareHeight = 25;

        public GameboardViewModel(Gameboard model)
        {
            GameboardVM = new ObservableCollection<GameboardSquareViewModel>();

            for(int i=0; i<model.size;i++)
            {
                GameboardSquareViewModel vm = new GameboardSquareViewModel(model.GameBoard[i], i, squareWidth, squareHeight);
                GameboardVM.Add(vm);
            }
        }

        /// <summary>
        /// Default width of a gameboard square
        /// </summary>
        public double Width
        {
            get => squareWidth;
            set => squareWidth = value;
        }

        /// <summary>
        /// Default height of a gameboard square
        /// </summary>
        public double Height
        {
            get => squareHeight;
            set => squareHeight = value;
        }


    }
}
