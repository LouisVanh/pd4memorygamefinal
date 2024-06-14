namespace MemoryGame.Model.States
{
    public interface IBoardState
    {
        public BoardStates State { get; }
        public MemoryBoardModel BoardModel { get; }
        public void AddPreview(TileModel tile);

        public void TileAnimationEnded(TileModel tile);
    }
}
