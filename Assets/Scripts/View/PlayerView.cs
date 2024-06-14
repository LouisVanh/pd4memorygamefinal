using MemoryGame.Model;
using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace MemoryGame.View
{
    public class PlayerView : ViewBaseClass<PlayerModel>
    {
        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _playerScore;
        [SerializeField] private TextMeshProUGUI _playerTime;

        private Color _playerColor;

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateUI();
            UpdateFontStyle();
        }

        private void UpdateUI()
        {
            _playerName.text = Model.Name;
            _playerScore.text = $"Score: {Model.Score.ToString()}";
            _playerTime.text = $"Time: {Model.mm.ToString("D2")}:{Model.ss.ToString("D2")}:{Model.ms.ToString("D3")}";
            //_playerTime.text = $"Time: {Model.Elapsed}";
        }

        private void UpdateFontStyle()
        {
            if (Model.IsActive)
            {
                _playerName.fontStyle = FontStyles.Bold | FontStyles.Underline;
                _playerName.fontSize = 60;
                _playerName.color = Color.green;
            }
            else
            {
                _playerName.fontStyle = FontStyles.Normal;
                _playerName.fontSize = 50;
                _playerName.color = new Color(0.21f, 0.05f, 0.18f);
            }
        }

        private void Update()
        {
            if (Model.IsActive)
            {
                Model.Elapsed += Time.deltaTime;
            }
        }
    }
}