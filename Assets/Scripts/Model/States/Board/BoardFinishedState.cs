namespace MemoryGame.Model.States
{
    public class BoardFinishedState : BoardStateBaseClass // DONE
    {
        public override BoardStates State => BoardStates.Finished; // go to end screen if u got one
        public BoardFinishedState(MemoryBoardModel boardModel) : base(boardModel)
        {
        }


        public override void AddPreview(TileModel tile)
        {
            //EMPTY
        }

        public override void TileAnimationEnded(TileModel tile)
        {
            //empty
        }
    }
}