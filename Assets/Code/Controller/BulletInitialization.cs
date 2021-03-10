namespace JevLogin
{
    public class BulletInitialization
    {
        #region Fields

        private BulletPool _bulletPool;

        #endregion


        #region ClassLifeCycles

        public BulletInitialization(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        #endregion


        #region Methods

        public BulletPool GetBulletPool()
        {
            return _bulletPool;
        }

        #endregion
    }
}