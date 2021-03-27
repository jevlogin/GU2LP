using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Data/Quest/QuestItemConfig", order = 51)]
    public sealed class QuestItemConfig : ScriptableObject
    {
        public int QuestId;
        public List<int> QuestItemIdCollection;
    }
}