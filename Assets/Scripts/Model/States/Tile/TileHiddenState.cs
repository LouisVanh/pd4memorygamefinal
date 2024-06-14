namespace MemoryGame.Model.States
{
    public class TileHiddenState : TileStateBaseClass
    {
        public override TileStates State => TileStates.Hidden;

        public TileHiddenState(TileModel tile) : base(tile)
        {

        }
    }
}
