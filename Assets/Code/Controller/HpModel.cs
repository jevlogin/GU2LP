namespace JevLogin
{
    public sealed class HpModel : IHpModel
    {
        #region Properties

        public float MaxHp { get; }
        public float CurrentHp { get; set; }

        #endregion


        #region ClassLifeCycles

        public HpModel(int maxHp)
        {
            MaxHp = maxHp;
            CurrentHp = MaxHp;
        }

        #endregion
    }
}