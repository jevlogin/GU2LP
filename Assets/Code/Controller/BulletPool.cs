using UnityEngine;


namespace JevLogin
{
    public sealed class BulletPool : GenericObjectPool<BulletView>
    {
        public BulletPool(Pool<BulletView> pool, Transform transformParent) : base(pool, transformParent)
        {
        }
    }
}