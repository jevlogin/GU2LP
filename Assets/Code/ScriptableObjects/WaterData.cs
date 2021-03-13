using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "WaterData", menuName = "Data/WaterData", order = 51)]
    public sealed class WaterData : ScriptableObject
    {
        [Header("Свойства воды."), Space(20)] public WaterStruct WaterStruct;
        [Header("Содержит всевозможные настройки для воды."), Space(20)] public WaterSettingsData WaterSettingsData;
    }
}