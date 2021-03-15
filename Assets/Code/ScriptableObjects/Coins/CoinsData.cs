using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "Data/CoinsData", order = 51)]
    public sealed class CoinsData : ScriptableObject
    {
        #region Fields

        [Header("Свойства игрока:"), Space(20)] public CoinStruct CoinStruct;
        [Header("Содержит компоненты."), Space(20)] public CoinComponents CoinComponents;
        [Header("Содержит всевозможные настройки для игрока."), Space(20)] public CoinSettingsData CoinSettingsData;

        #endregion
    }
}