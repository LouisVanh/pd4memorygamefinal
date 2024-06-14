namespace MemoryGame.Model.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public BoardNoPreviewState(MemoryBoardModel board) : base(board)
        {
            ToggleActivePlayer(board);
        }

        public override BoardStates State => BoardStates.NoPreview;

        public override void AddPreview(TileModel card)
        {
            if (card.State.State != TileStates.Hidden)
            {
                return;
            }

            card.State = new TilePreviewState(card);
            card.Board.PreviewTiles.Add(card);
            card.Board.BoardState = new BoardOnePreviewState(card.Board);

        }

        public override void TileAnimationEnded(TileModel card)
        {
            //not interested when animations end: empty body
        }
        private void ToggleActivePlayer(MemoryBoardModel board)
        {
            if (board.Players != null && board.Players.Count > 0)
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