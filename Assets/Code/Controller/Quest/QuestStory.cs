using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class QuestStory : IQuestStory
    {
        #region Fields

        private readonly List<IQuest> _questsCollections = new List<IQuest>();

        #endregion


        #region Properties

        public bool IsDone => _questsCollections.All(value => value.IsCompleted);

        #endregion


        #region ClassLifeCycles

        public QuestStory(List<IQuest> questsCollections)
        {
            _questsCollections = questsCollections ?? throw new System.ArgumentNullException(nameof(questsCollections));
            Subscribe();
            ResetQuest(0);
        }

        #endregion


        private void ResetQuest(int index)
        {
            if (index < 0 || index > _questsCollections.Count)
            {
                return;
            }
            var nextQuest = _questsCollections[index];
            if (nextQuest.IsCompleted)
            {
                OnQuestCompleted(this, nextQuest);
            }
            else
            {
                _questsCollections[index].Reset();
            }
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollections)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void Unsubscribe()
        {
            foreach (var quest in _questsCollections)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollections.IndexOf(quest);
            if (IsDone)
            {
                Debug.Log("Story done!");
            }
            else
            {
                if (index < _questsCollections.Count - 1)
                {
                    ResetQuest(++index);
                }
            }
        }

        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollections)
            {
                quest.Dispose();
            }
        }
    }
}