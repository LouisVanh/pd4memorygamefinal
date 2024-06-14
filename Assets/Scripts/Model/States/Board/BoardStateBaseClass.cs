namespace MemoryGame.Model.States
{
    public abstract class BoardStateBaseClass : IBoardState
    {
        public abstract BoardStates State { get;}
        public MemoryBoardModel BoardModel { get; set; }
        public BoardStateBaseClass (MemoryBoardModel boardModel)
        {
            BoardModel = boardModel;
        }

        public abstract void AddPreview(TileModel tile);
        public abstract void TileAnimationEnded(TileModel tile);
    }
}
