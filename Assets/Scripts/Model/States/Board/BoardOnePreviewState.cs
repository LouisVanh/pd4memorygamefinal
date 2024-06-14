namespace MemoryGame.Model.States
{
    public class BoardOnePreviewState : BoardStateBaseClass //DONE
    {
        public BoardOnePreviewState(MemoryBoardModel boardModel) : base(boardModel)
        {
        }

        public override BoardStates State => BoardStates.OnePreview;


        public override void AddPreview(TileModel tile)
        {
            if (tile.State.State != TileStates.Hidden)
            {
                return;
            }
            tile.Board.PreviewTiles.Add(tile);

            if (tile.Board.IsCombinationFound)
            {
                tile.Board.BoardState = new BoardTwoFoundState(tile.Board);
                foreach (TileModel tile1 in tile.Board.PreviewTiles)
                {
                    tile1.State = new TileFoundState(tile1);
                }
            }
            else
            {
                tile.Board.BoardState = new BoardTwoPreviewState(tile.Board);
                tile.State = new TilePreviewState(tile);
            }
        }


        public override void TileAnimationEnded(TileModel tile)
        {
            // EMPTY BODY
        }

    }
}