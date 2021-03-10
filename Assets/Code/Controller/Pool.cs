using UnityEngine;


namespace JevLogin
{
    public class Pool<T> where T : Component
    {
        #region Fields

        public T Prefab;
        public int Size;

        #endregion


        #region ClassLifeCycles

        public Pool(int count, string path)
        {
            Size = count;
            Prefab = Resources.Load<T>(path);
        }

        #endregion
    }
}