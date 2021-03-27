using UnityEngine;


namespace JevLogin
{
    public interface IQuestModel 
    {
        bool TryComplete(GameObject activator);
    }
}