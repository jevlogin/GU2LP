using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class HpViewModel : IHpViewModel
    {
        public IHpModel HpModel { get; }
        public event Action<bool> IsDeads = delegate (bool value) { };
        private bool _isDead;

        public bool IsDead => _isDead;

        public HpViewModel(IHpModel hpModel)
        {
            HpModel = hpModel;
        }

        public event Action<float> OnHpChange = delegate (float value) { };

        public void ApplyDamage(float damage)
        {
            HpModel.CurrentHp -= damage;

            if (HpModel.CurrentHp <= 0)
            {
                _isDead = true;
                IsDeads.Invoke(_isDead);
            }
            OnHpChange.Invoke(HpModel.CurrentHp);
        }
    }
}