
namespace MemoryGame.Model.States
{
    public interface ITileState
    {
        public TileStates State { get; }

        public TileModel Tile { get; }
    }
}
