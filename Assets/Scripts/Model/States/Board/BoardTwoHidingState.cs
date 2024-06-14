namespace MemoryGame.Model.States
{
    public class BoardTwoHiding : BoardStateBaseClass // DONE
    {
        public override BoardStates State => BoardStates.TwoHiding;
        public BoardTwoHiding(MemoryBoardModel boardModel) : base(boardModel)
        {
        }

        public override void AddPreview(TileModel tile)
        {
            // empty body
        }

        public override void TileAnimationEnded(TileModel tile)
        {
            tile.Board.PreviewTiles.Remove(tile);
            if(tile.Board.PreviewTiles.Count == 0)
            {
                tile.Board.BoardState = new BoardNoPreviewState(tile.Board);
            }
        }
    }
}
