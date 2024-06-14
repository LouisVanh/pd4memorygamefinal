namespace MemoryGame.Model
{
    public class PlayerModel : ModelBaseClass
    {
        private string _name;
        private int _score;
        private bool _isActive;
        private float _elapsed;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                if (_score == value) return;
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public float Elapsed
        {
            get => _elapsed;
            set
            {
                if (_elapsed == value) return;
                _elapsed = value;
                OnPropertyChanged(nameof(Elapsed));
            }
        }
        public int mm => (int)(Elapsed / 60);

        public int ss => (int)(Elapsed % 60);

        public int ms => (int)((Elapsed % 1) * 1000);
    }
}