using System.Collections.Generic;
using UnityEngine;
using MemoryGame.Model;
using System.Collections;
using System.Runtime.InteropServices;

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

        private void Start()
        {
            // Set up the memory board
            //_endGame.SetActive(false);
            _memoryBoardModel = new MemoryBoardModel(3, 3);
            _board.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_memoryBoardModel, TilePrefab);
            List<PlayerModel> players = new List<PlayerModel>();


            //GameObject player = GameObject.Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity, _canvas.transform);
            _playerView1.Model = new PlayerModel();
            _playerView1.Model.Name = $"Player 1";
            _playerView1.Model.Score = 0;
            _playerView1.Model.IsActive = true;
            _playerView1.Model.Elapsed = 0;
            players.Add(_playerView1.Model);


            //_playerView2 = _player2.GetComponent<PlayerView>();
            _playerView2.Model = new PlayerModel();
            _playerView2.Model.Name = $"Player 2";
            _playerView2.Model.Score = 0;
            _playerView2.Model.IsActive = false;
            _playerView2.Model.Elapsed = 0;

            players.Add(_playerView2.Model);


            _memoryBoardModel.Players = players;
        }

        private void Update()
        {
            Debug.Log(_memoryBoardModel.BoardState);


            try
            {
                _playerView1.Model.Name = UpdateName1();
                _playerView2.Model.Name = UpdateName2();

            }
            catch
            {
                Debug.Log("FAILED TO UPDATE NAME");
            }
        }
        private IEnumerator PlayEndScreen()
        {

            yield return new WaitForSeconds(1f);
            //_endGame.SetActive(true);
        }
    }

}

