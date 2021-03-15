using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

        [Header("�������� ������:"), Space(20)] public PlayerStruct PlayerStruct;
        [Header("�������� ����������."), Space(20)] public PlayerComponents PlayerComponents;
        [Header("�������� ������������ ��������� ��� ������."), Space(20)] public PlayerSettingsData PlayerSettingsData;

        #endregion
    }
}