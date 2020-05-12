using OthelloServer.Models;
using System.Collections.ObjectModel;

namespace OthelloServer.ViewModels
{
    public class GameboardViewModel
    {
        // Our collecxtion of GamevoardVM
        private ObservableCollection<GameboardSquareViewModel> GameboardVM { get; set; }

        private double squareWidth = 25;
        private double squareHeight = 25;

        public GameboardViewModel(Gameboard model)
        {
            GameboardVM = new ObservableCollection<GameboardSquareViewModel>();

            for(int i=0; i<model.size;i++)
            {
                GameboardSquareViewModel vm = new GameboardSquareViewModel(model.GameBoard[i], i);
                GameboardVM.Add(vm);
            }

        }
    }
}
