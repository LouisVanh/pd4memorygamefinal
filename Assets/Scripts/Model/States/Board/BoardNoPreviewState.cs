namespace MemoryGame.Model.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public BoardNoPreviewState(MemoryBoardModel board) : base(board)
        {
            // When the no preview state is enabled (constructed) --) could be on start, or after twofound/twohidden
            ToggleActivePlayer(board);
        }

        public override BoardStates State => BoardStates.NoPreview;

        public override void AddPreview(TileModel tile)
        {
            if (tile.State.State != TileStates.Hidden)
            {
                return;
            }

            tile.State = new TilePreviewState(tile);
            tile.Board.PreviewTiles.Add(tile);
            tile.Board.BoardState = new BoardOnePreviewState(tile.Board);

        }

        public override void TileAnimationEnded(TileModel card)
        {
            //not interested when animations end: empty body
        }
        private void ToggleActivePlayer(MemoryBoardModel board)
        {
            if (board.Players != null && board.Players.Count > 0) // if there's players
            {
                board.ActivePlayer += 1;
                if (board.ActivePlayer >= board.Players.Count)
                {
                    board.ActivePlayer = 0;
                }

                foreach (PlayerModel player in board.Players)
                {
                    player.IsActive = false;
                }

                if (board.Players.Count > 0)
                {
                    board.Players[board.ActivePlayer].IsActive = true;
                }
            }

            //Board.PreviewTiles = new List<Tile>();
        }
    }
}