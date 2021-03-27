using UnityEngine;


namespace JevLogin
{
    public sealed class SwitchQuestModel : IQuestModel
    {
        #region IQuestModel

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(ManagerPath.PLAYER);
        } 

        #endregion
    }
}