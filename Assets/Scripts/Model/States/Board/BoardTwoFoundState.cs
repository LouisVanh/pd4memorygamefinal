using System.Linq;

namespace MemoryGame.Model.States
{
    public class BoardTwoFoundState : BoardStateBaseClass // DONE
    {
        public BoardTwoFoundState(MemoryBoardModel board) : base(board)
        {
            board.Players[board.ActivePlayer].Score++; // INCREASE PLAYER SCORE HERE ONLY
        }

        public override BoardStates State => BoardStates.TwoFound;

        public override void AddPreview(TileModel tile)
        {
            // empty body (there's 2 found, no preview needed)
        }

        public override void TileAnimationEnded(TileModel tile)
        {
            //if (Board.PreviewingTiles[1] == tile) // SAME THING FOR 2?
            if (tile.Board.PreviewTiles[tile.Board.PreviewTiles.Count - 1] == tile)
            {
                if (tile.Board.TileModels.Where(t => t.State.State == TileStates.Hidden).Count() < 2)
                {
                    tile.Board.BoardState = new BoardFinishedState(tile.Board);
                }
                else
                {
                    tile.Board.PreviewTiles.Clear();
                    tile.Board.BoardState = new BoardNoPreviewState(tile.Board);
                }
            }

        }
    }
}
