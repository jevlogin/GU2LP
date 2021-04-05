using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(menuName = "Data/Quest/QuestConfig", fileName = "QuestConfig", order = 51)]
    public sealed class QuestConfig : ScriptableObject
    {
        public int Id;
        public QuestType QuestType;
    }
}