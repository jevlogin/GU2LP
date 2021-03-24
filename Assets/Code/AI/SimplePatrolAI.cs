using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class SimplePatrolAI
    {
        #region Fields

        private readonly LevelObjectView _view;
        private readonly SimplePatrolModel _model;

        #endregion


        #region ClassLifeCycles

        public SimplePatrolAI(LevelObjectView view, SimplePatrolModel model)
        {
            _view = view != null ? view : throw new System.ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new System.ArgumentNullException(nameof(model));
        }

        #endregion


        #region UnityMethods

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.Transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody2D.velocity = newVelocity;
        }

        #endregion
    }
}