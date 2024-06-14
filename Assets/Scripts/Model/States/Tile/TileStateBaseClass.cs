namespace MemoryGame.Model.States
{
    public abstract class TileStateBaseClass : ITileState
    {
        public TileModel Tile { get; private set; }

        public abstract TileStates State { get;}

        public TileStateBaseClass(TileModel tile)
        {
            Tile = tile;
        }
    }
}
