using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Data/Quest/QuestStoryConfig", order = 51)]
    public sealed class QuestStoryConfig : ScriptableObject
    {
        [Header("Список квестов.")]
        public QuestConfig[] QuestConfigs;

        [Header("Тип квеста."), Space(10)]
        public QuestStoryType QuestStoryType;
    }
}