using MemoryGame.Model.States;
using System.Collections.Generic;
using MemoryGame.Utilities;
using MemoryGame.Data;

namespace MemoryGame.Model
{
    public class MemoryBoardModel : ModelBaseClass
    {
        private IBoardState _boardState;
        public IBoardState BoardState
        {
            get { return _boardState; }
            set
            {
                if (BoardState == value) return;
                _boardState = value;
                OnPropertyChanged(); //in case we want anything to happen when this gets changed
            }
        }
        private MemoryBoardModel _board;

        private float _timer; //just for updating the memorycardid every 2sec

        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public List<TileModel> TileModels { get; private set; }

        //the list of tiles which are currently shown in preview to the user
        public List<TileModel> PreviewTiles { get; set; }

        public bool IsCombinationFound
        {
            get //if the selected cards are the same
            {
                if (PreviewTiles.Count == 2
                    && PreviewTiles[0].MemoryCardId == PreviewTiles[1].MemoryCardId)
                    return true; // if the property previewingtiles contains exactly 2 tiles which both have the same image (aka id)
                return false;
            }
        }

        public List<PlayerModel> Players = new List<PlayerModel>();
        public int ActivePlayer = 0;


        public MemoryBoardModel(int rows, int columns) // CREATION OF THE MEMORY BOARD MODEL (CONSTRUCTOR)
        {
            Rows = rows;
            Columns = columns;
            TileModels = new List<TileModel>();
            PreviewTiles = new List<TileModel>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TileModels.Add(new TileModel(i, j, this));
                }
            }

            // Change this for exam: BoardWaitStartState
            //BoardState = new BoardNoPreviewState(this);
            BoardState = new BoardWaitStartState(this);
            AssignMemoryCardIds();
        }
        private void AssignMemoryCardIds()
        {
            ImageRepository repo = ImageRepository.Instance;
            repo.ProcessImageIds(AssignMemoryCardIds);
        }

        private void AssignMemoryCardIds(List<int> memoryCardIds)
        {
            memoryCardIds = memoryCardIds.Shuffle();

            bool first = true;

            TileModels = TileModels.Shuffle();
            foreach (var card in TileModels)
            {
                card.MemoryCardId = memoryCardIds[0];
                if (first)
                {
                    first = false;
                }
                else
                {
                    memoryCardIds.RemoveAt(0);
                    first = true;
                }
            }
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }

    }
}