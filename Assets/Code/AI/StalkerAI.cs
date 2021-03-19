using Pathfinding;
using System;
using UnityEngine;


namespace JevLogin
{
    internal class StalkerAI
    {
        #region Fields

        private readonly LevelObjectView _view;
        private readonly StalkerAIModel _model;
        private readonly Seeker _seeker;
        private readonly Transform _target;

        #endregion


        #region ClassLifeCycles

        public StalkerAI(LevelObjectView stalkerAIView, StalkerAIModel stalkerAIModel, Seeker stalkerAISeeker, Transform stalkerAITarget)
        {
            _view = stalkerAIView != null ? stalkerAIView : throw new System.ArgumentNullException(nameof(stalkerAIView));
            _model = stalkerAIModel != null ? stalkerAIModel : throw new System.ArgumentNullException(nameof(stalkerAIModel));
            _seeker = stalkerAISeeker != null ? stalkerAISeeker : throw new System.ArgumentNullException(nameof(stalkerAISeeker));
            _target = stalkerAITarget != null ? stalkerAITarget : throw new System.ArgumentNullException(nameof(stalkerAITarget));
        }

        #endregion


        #region Methods

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody2D.velocity = newVelocity;
        }

        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_view.Rigidbody2D.position, _target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error)
            {
                return;
            }
            _model.UpdatePath(p);
        }

        #endregion
    }
}