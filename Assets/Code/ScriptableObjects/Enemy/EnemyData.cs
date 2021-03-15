using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 51)]
    public sealed class EnemyData : ScriptableObject
    {
        #region Fields

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
                    _spriteAnimatorConfig = Resources.Load<SpriteAnimatorConfig>(Path.Combine(ManagerPath.DATA, ManagerPath.ENEMY, ManagerName.SPRITE_ANIMATOR_CONFIG));
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