using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public struct PlayerStruct
    {
        #region Fields

        public Transform SpawnPlayer;

        [Header("Состояние игрока:")] public AnimState AnimState;

        [Range(0, 1000), Space(20)] public float WalkSpeed;
        [Range(0, 30)] public float AnimationSpeed;
        [Range(0, 20)] public float JumpForce;
        [Range(0, 1)] public float JumpTresh;
        [Range(0, 1)] public float MovingThrash;
        [Range(0, 5)] public float FlyThresh;
        [Range(0, 5)] public float GroundLevel;
        [Range(0, 100)] public int _healthPoint;

        [Header("Вектор поворота игрока:"), Space(10)]
        public Vector3 LeftScale;
        public Vector3 RightScale;

        [Header("Не понятные настройки игрока:"), Space(10)]
        public float YVelocity;
        public bool DoJump;

        #endregion
    }
}