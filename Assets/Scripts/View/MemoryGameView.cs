using System.Collections.Generic;
using UnityEngine;
using MemoryGame.Model;
using System.Collections;
using System.Runtime.InteropServices;
using MemoryGame.Model.States;

namespace MemoryGame.View
{
    public class MemoryGameView : MonoBehaviour
    {

        public GameObject TilePrefab;
        [SerializeField] private GameObject _board; // board in scene
        private MemoryBoardModel _memoryBoardModel;
        [SerializeField] private PlayerView _playerView1;
        [SerializeField] private PlayerView _playerView2;

        // Assets/Plugins --) these are the scripts here
        [DllImport("__Internal")] private static extern string UpdateName1();
        [DllImport("__Internal")] private static extern string UpdateName2();

        //New exam requirement: start game through button after 
        [DllImport("__Internal")] private static extern void StartGameThroughButton();


        private void Start()
        {
            // Set up the memory board
            //_endGame.SetActive(false);
            _memoryBoardModel = new MemoryBoardModel(3, 3);
            _board.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_memoryBoardModel, TilePrefab);
            //InitializePlayers(); //removed, because this needs to happen only after the boardwaitstartstate is over
        }

        public void InitializePlayers()
        {
            List<PlayerModel> players = new List<PlayerModel>();


            _playerView1.Model = new PlayerModel();
            _playerView1.Model.Name = $"Player 1";
            _playerView1.Model.Score = 0;
            _playerView1.Model.IsActive = true;
            _playerView1.Model.Elapsed = 0;
            players.Add(_playerView1.Model);


            _playerView2.Model = new PlayerModel();
            _playerView2.Model.Name = $"Player 2";
            _playerView2.Model.Score = 0;
            _playerView2.Model.IsActive = false;
            _playerView2.Model.Elapsed = 0;

            players.Add(_playerView2.Model);


            _memoryBoardModel.Players = players;
        }

        public void StartGameButtonClicked()
        {
            InitializePlayers();
            Time.timeScale = 1;
            Debug.Log("START BUTTON CLICKED!");
            _memoryBoardModel.BoardState = new BoardNoPreviewState(_memoryBoardModel);

            // maybe assign new state?
        }
        private void Update()
        {
            Debug.Log(_memoryBoardModel.BoardState);


            //try
            //{
            //    _playerView1.Model.Name = UpdateName1();
            //    _playerView2.Model.Name = UpdateName2();

            //}
            //catch
            //{
            //    Debug.Log("FAILED TO UPDATE NAME");
            //}
        }
        //private IEnumerator PlayEndScreen()
        //{

        //    yield return new WaitForSeconds(1f);
        //    //_endGame.SetActive(true);
        //}
    }

}

