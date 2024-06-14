using UnityEngine;
using MemoryGame.Model;
using System.ComponentModel;
using UnityEngine.EventSystems;
using MemoryGame.Model.States;
using MemoryGame.Data;

namespace MemoryGame.View
{
    public class TileView : ViewBaseClass<TileModel>, IPointerDownHandler, IPointerEnterHandler
    {
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
            AddEvents(); // not implemented yet!
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            this.Model.Board.BoardState.AddPreview(this.Model);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log(Model.MemoryCardId);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                StartAnimation();
            }
            else if (e.PropertyName.Equals(nameof(Model.MemoryCardId)))
            {
                LoadFront();
                LoadBack();
            }
        }

        private void LoadFront()
        {
            ImageRepository.Instance.GetProcessTexture(Model.MemoryCardId, LoadFront);
        }
        private void LoadFront(Texture2D texture)
        {
            gameObject.transform.Find("BottomCard").GetComponent<Renderer>().material.mainTexture = texture;
        }

        private void LoadBack()
        {
            ImageRepository.Instance.GetProcessTexture(5, LoadBack); // amount of images = 5
        }

        private void LoadBack(Texture2D texture)
        {
            gameObject.transform.Find("TopCard").GetComponent<Renderer>().material.mainTexture = texture;
        }

        private void AddEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                // ADD EVENTS HERE

                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];

                AnimationEvent animationStartEvent = new AnimationEvent();
                animationStartEvent.time = 0;
                animationStartEvent.functionName = "AnimationStartHandler";
                animationStartEvent.stringParameter = clip.name;

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationEndHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationStartEvent);
                clip.AddEvent(animationEndEvent);
            }
        }

        public void AnimationStartHandler(string eventName)
        {
            // EMPTY
        }

        public void AnimationEndHandler(string eventName)
        {
            Debug.Log($"Animation ended: {eventName}");
            Model.Board.BoardState.TileAnimationEnded(Model);
        }
        private void StartAnimation()
        {
            _animator.speed = 1.25f;
            switch (this.Model.State.State)
            {
                case TileStates.Hidden:
                    _animator.Play("Hidden");
                    break;
                case TileStates.Preview:
                    _animator.Play("Shown");
                    break;
                case TileStates.Found:
                    _animator.Play("Shown");
                    break;
            }
        }
    }
}