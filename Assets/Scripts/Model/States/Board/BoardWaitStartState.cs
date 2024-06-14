using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryGame.Model.States
{
    public class BoardWaitStartState : BoardStateBaseClass
    {
        public BoardWaitStartState(MemoryBoardModel memoryBoardModel) : base(memoryBoardModel)
        {
            // START OF GAME:
            //NO PLAYER INITIALISED
            Time.timeScale = 0;
            //StartGameButtonClicked() will undo this
        }
        public override BoardStates State => BoardStates.WaitStart;

        public override void AddPreview(TileModel tile)
        {
        }

        public override void TileAnimationEnded(TileModel tile)
        {
        }

    }
}
