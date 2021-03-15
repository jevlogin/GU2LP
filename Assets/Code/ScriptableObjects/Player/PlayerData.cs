using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

        [Header("Свойства игрока:"), Space(20)] public PlayerStruct PlayerStruct;
        [Header("Содержит компоненты."), Space(20)] public PlayerComponents PlayerComponents;
        [Header("Содержит всевозможные настройки для игрока."), Space(20)] public PlayerSettingsData PlayerSettingsData;

        #endregion
    }
}