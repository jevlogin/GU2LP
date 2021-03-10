using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class SpriteAnimatorController : IDisposable, IExecute
    {
        #region Fields

        private SpriteAnimatorConfig _spriteAnimatorConfig;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

        #endregion


        #region ClassLifeCycles

        public SpriteAnimatorController(SpriteAnimatorConfig spriteAnimatorConfig)
        {
            _spriteAnimatorConfig = spriteAnimatorConfig;
        }

        #endregion


        #region Methods

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState animState, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;

                if (animation.AnimState != animState)
                {
                    animation.AnimState = animState;
                    animation.Sprites = _spriteAnimatorConfig.SpriteSequences.Find(sequence => sequence.AnimState == animState).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    AnimState = animState,
                    Sprites = _spriteAnimatorConfig.SpriteSequences.Find(sequence => sequence.AnimState == animState).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimations.ContainsKey(spriteRenderer))
            {
                _activeAnimations.Remove(spriteRenderer);
            }
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Execute(deltaTime);
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }

        #endregion


        #region IDispose

        public void Dispose()
        {
            _activeAnimations.Clear();
        }

        #endregion
    }
}
