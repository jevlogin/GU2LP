using System;


namespace JevLogin
{
    public interface IHpViewModel
    {
        IHpModel HpModel { get; }
        bool IsDead { get; }
        void ApplyDamage(float damage);
        event Action<float> OnHpChange;
        event Action<bool> IsDeads;

    }
}