using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class EnvironmentView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public int SortingOrder;
        public float Offset; 
    }
}