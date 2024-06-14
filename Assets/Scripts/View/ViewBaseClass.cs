using System.ComponentModel;
using UnityEngine;

namespace MemoryGame.View
{
    public abstract class ViewBaseClass<T> : MonoBehaviour where T : class, INotifyPropertyChanged
    {
        [SerializeField] private T _model;

        public T Model
        {
            get => _model;
            set
            {
                if (_model == value)
                {
                    return;
                }

                if (null != _model)
                {
                    _model.PropertyChanged -= Model_PropertyChanged;
                }

                _model = value;
                Model.PropertyChanged += Model_PropertyChanged;
            }
        }

        protected abstract void Model_PropertyChanged(object sender, PropertyChangedEventArgs e);
    }
}