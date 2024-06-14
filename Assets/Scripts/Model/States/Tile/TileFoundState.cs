namespace MemoryGame.Model.States
{
    public class TileFoundState : TileStateBaseClass
    {
        public override TileStates State => TileStates.Found;

        public TileFoundState(TileModel tile) : base(tile)
        {

        }
    }
}