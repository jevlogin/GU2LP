using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;

        private EnemyData _enemyData;
        private PlayerData _playerData;

        public EnemyData EnemyData
        {
            get
            {
                if (_enemyData == null)
                {
                    _enemyData = Resources.Load<EnemyData>(Path.Combine(ManagerPath.DATA, ManagerPath.ENEMY, ManagerName.ENEMY_DATA));
                    if (_enemyData == null)
                    {
                        _enemyData = Resources.Load<EnemyData>(Path.Combine(ManagerPath.DATA, _enemyDataPath));
                    }
                }
                return _enemyData;
            }
        }

        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Resources.Load<PlayerData>(Path.Combine(ManagerPath.DATA, ManagerPath.PLAYER, ManagerName.PLAYER_DATA));
                    if (_playerData == null)
                    {
                        _playerData = Resources.Load<PlayerData>(Path.Combine(ManagerPath.DATA, _playerDataPath));
                    }
                }
                return _playerData;
            }
        }


    }
}