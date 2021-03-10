using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public class GenericObjectPool<T> where T : Component
    {
        #region Fields

        private Queue<T> _objects = new Queue<T>();
        public Pool<T> Pool;
        private Transform _transformParent;
        private Transform _transformPool;
        private Pool<BulletView> pool;
        private Transform transformParent;

        #endregion


        #region ClassLifeCycles

        public GenericObjectPool(Pool<T> pool, Transform transformParent)
        {
            Pool = pool;
            _transformParent = transformParent;

            if (!_transformParent)
            {
                _transformParent = new GameObject(nameof(Pool.Prefab)).transform;
            }
        }

        #endregion


        #region Methods

        public T Get()
        {
            if (_objects.Count == 0)
            {
                AddObjects(Pool.Size);
            }
            return _objects.Dequeue();
        }

        public List<T> GetList()
        {
            List<T> result = new List<T>();

            if (_objects.Count == 0)
            {
                AddObjects(Pool.Size);
            }
            foreach (var item in _objects)
            {
                result.Add(item);
            }

            return result;
        }

        private void AddObjects(int count)
        {
            switch (typeof(T).Name)
            {
                case ManagerPath.BULLET_VIEW:
                    _transformPool = new GameObject(ManagerName.POOL_BULLETS).transform;
                    break;
                default:
                    throw new System.ArgumentException("Нет такого типа", nameof(T));
            }

            _transformPool.SetParent(_transformParent);

            for (int i = 0; i < count; i++)
            {
                var newObject = Object.Instantiate(Pool.Prefab);

                newObject.transform.SetParent(_transformPool);

                newObject.gameObject.SetActive(false);

                _objects.Enqueue(newObject);
            }
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);

            objectToReturn.transform.SetParent(_transformPool);

            _objects.Enqueue(objectToReturn);
        }

        #endregion


    }
}