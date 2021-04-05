using System.IO;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _waterDataPath;
        [SerializeField] private string _coinsDataPath;
        [SerializeField] private string _hudDataPath;

        private EnemyData _enemyData;
        private PlayerData _playerData;
        private WaterData _waterData;
        private CoinsData _coinsData;
        private HudData _hudData;

        #endregion


        #region Properties

        public HudData HudData
        {
            get
            {
                if (_hudData == null)
                {
                    _hudData = Resources.Load<HudData>(Path.Combine(ManagerPath.DATA, ManagerName.HUD_DATA));
                    if (_hudData == null)
                    {
                        _hudData = Resources.Load<HudData>(Path.Combine(ManagerPath.DATA, _hudDataPath));
                    }
                }
                return _hudData;
            }
        }

        public CoinsData CoinsData
        {
            get
            {
                if (_coinsData == null)
                {
                    _coinsData = Resources.Load<CoinsData>(Path.Combine(ManagerPath.DATA, ManagerPath.COINS, ManagerName.COINS_DATA));
                    if (_coinsData == null)
                    {
                        _coinsData = Resources.Load<CoinsData>(Path.Combine(ManagerPath.DATA, _coinsDataPath));
                    }
                }
                return _coinsData;
            }
        }

        public WaterData WaterData
        {
            get
            {
                if (_waterData == null)
                {
                    _waterData = Resources.Load<WaterData>(Path.Combine(ManagerPath.DATA, ManagerPath.WATER, ManagerName.WATER_DATA));
                    if (_waterData == null)
                    {
                        _waterData = Resources.Load<WaterData>(Path.Combine(ManagerPath.DATA, _waterDataPath));
                    }
                }
                return _waterData;
            }
        }

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

        #endregion
    }
}