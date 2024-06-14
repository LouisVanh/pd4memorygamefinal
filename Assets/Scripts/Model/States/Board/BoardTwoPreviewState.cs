namespace MemoryGame.Model.States
{
    public class BoardTwoPreviewState : BoardStateBaseClass // DONE
    {
        public BoardTwoPreviewState(MemoryBoardModel boardModel) : base(boardModel)
        {

        }

        public override BoardStates State => BoardStates.TwoPreview;

        public override void AddPreview(TileModel tile)
        {
            // THIS CAN HAPPEN IF YOU CLICK VERY FAST ON MORE THAN 2 TILES
            // IT SHOULDN'T DO ANYTHING
            // EMPTY BODY!
        }

        public override void TileAnimationEnded(TileModel tile)
        {
            if (tile.Board.PreviewTiles[1] == tile) // if its the same card
            {
                tile.Board.PreviewTiles[0].State = new TileHiddenState(tile);
                tile.Board.PreviewTiles[1].State = new TileHiddenState(tile);

                tile.Board.BoardState = new BoardTwoHiding(tile.Board);
            }
        }
    }
}