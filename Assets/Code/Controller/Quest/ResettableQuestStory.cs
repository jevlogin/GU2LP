using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class ResettableQuestStory : IQuestStory
    {
        #region Fields

        private readonly List<IQuest> _questsCollection;
        private int _currentIndex;

        #endregion


        #region IQuestStory

        public bool IsDone => _questsCollection.All(value => value.IsCompleted);

        #endregion


        #region ClassLifeCycles

        public ResettableQuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection ?? throw new System.ArgumentNullException(nameof(questsCollection));
            Subscribe();
            ResetQuests();
        }

        #endregion


        #region Methods

        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _questsCollection)
            {
                quest.Reset();
            }
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone)
                {
                    Debug.Log("Story done!");
                }
            }
            else
            {
                ResetQuests();
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection)
            {
                quest.Dispose();
            }
        }

        #endregion
    }
}