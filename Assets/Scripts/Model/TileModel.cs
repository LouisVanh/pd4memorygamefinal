using MemoryGame.Model.States;

namespace MemoryGame.Model
{
    public class TileModel : ModelBaseClass
    {

        private ITileState _tileState;
        public ITileState State
        {
            get { return _tileState; }
            set
            {
                if (_tileState == value) return;
                _tileState = value;
                OnPropertyChanged(); //in case we want anything to happen when this gets changed
            }
        }

        public int Row { get; private set; }
        public int Column { get; private set; }

        public MemoryBoardModel Board;
        private int _memoryCardId;
        public int MemoryCardId
        {
            get { return _memoryCardId; }
            set
            {
                //if (_memoryCardId == value) return;
                _memoryCardId = value;
                OnPropertyChanged(); //in case we want to swap cards around 
            }
        }

        // constructor:
        public TileModel(int row, int column, MemoryBoardModel board)
        {
            Row = row;
            Column = column;
            Board = board;
            State = new TileHiddenState(this);
        }

        public override string ToString()
        {
            return $"Tile: {Row},{Column}";
        }
    }
}