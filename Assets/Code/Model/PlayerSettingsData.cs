using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public class PlayerSettingsData
    {
        #region Fields
        [Range(-100, 100)] public int SortingOrderSpriteRenderer;

        [Header("Настройка анимаций игрока:"), Space(20)]
        [SerializeField] private string _spriteAnimatorPath;

        private SpriteAnimatorConfig _spriteAnimatorConfig;

        #endregion


        #region Properties

        public SpriteAnimatorConfig SpriteAnimatorConfig
        {
            get
            {
                if (_spriteAnimatorConfig == null)
                {
                    _spriteAnimatorConfig = Resources.Load<SpriteAnimatorConfig>(Path.Combine(ManagerPath.DATA, ManagerPath.PLAYER, ManagerName.SPRITE_ANIMATOR_CONFIG));
                    if (_spriteAnimatorConfig == null)
                    {
                        _spriteAnimatorConfig = Resources.Load<SpriteAnimatorConfig>(Path.Combine(ManagerPath.DATA, _spriteAnimatorPath));
                    }
                }
                return _spriteAnimatorConfig;
            }
        }

        #endregion
    }
}