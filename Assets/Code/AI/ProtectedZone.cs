using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ProtectedZone
    {
        #region Fields

        private List<IProtector> _protectors;
        private LevelObjectTrigger _view;

        #endregion


        #region ClassLifeCycles

        public ProtectedZone(LevelObjectTrigger view, List<IProtector> protectors)
        {
            _view = view != null ? view : throw new System.ArgumentNullException(nameof(view));
            _protectors = protectors != null ? protectors : throw new System.ArgumentNullException(nameof(protectors));
        }

        #endregion

        public void Init()
        {
            _view.TriggerEnter += OnContact;
            _view.TriggerExit += OnExit;
        }

        public void Deinit()
        {
            _view.TriggerEnter -= OnContact;
            _view.TriggerExit -= OnExit;
        }

        private void OnExit(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.FinishProtection(gameObject);
            }
        }

        private void OnContact(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.StartProtection(gameObject);
            }
        }
    }
}