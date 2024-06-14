
namespace MemoryGame.Model.States
{
    public class TilePreviewState : TileStateBaseClass
    {
        public override TileStates State => TileStates.Preview;
        public TilePreviewState(TileModel tile) : base(tile)
        {

        }

    }
}
