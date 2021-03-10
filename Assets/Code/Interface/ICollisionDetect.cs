using System;
using UnityEngine;


namespace JevLogin
{
    public interface ICollisionDetect
    {
        event Action<Collider2D> CollisionDetectChange;
    }
}