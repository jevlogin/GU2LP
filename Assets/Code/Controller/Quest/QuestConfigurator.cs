using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class QuestConfigurator : MonoBehaviour
    {
        #region Fields

        [SerializeField] private QuestObjectView _singleQuestView;

        [Header("Quest Story"), Space(10)]
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private QuestObjectView[] _questObjectViews;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>
            {
                { QuestType.Switch, () => new SwitchQuestModel() },
            };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
            {
                {
                    QuestStoryType.Common, questCollection => new QuestStory(questCollection)
                },
                {
                    QuestStoryType.Resettable, questCollection => new ResettableQuestStory(questCollection)
                }
            };

        private List<IQuestStory> _questStories;
        private Quest _singleQuest;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel());
            _singleQuest.Reset();

            _questStories = new List<IQuestStory>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private void OnDestroy()
        {
            foreach (var questStory in _questStories)
            {
                questStory.Dispose();
            }
            _questStories.Clear();
        }

        #endregion


        #region Methods

        private IQuestStory CreateQuestStory(QuestStoryConfig questStoryConfig)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in questStoryConfig.QuestConfigs)
            {
                var quest = CreateQuest(questConfig);
                if (quest == null)
                {
                    continue;
                }
                quests.Add(quest);
            }
            return _questStoryFactories[questStoryConfig.QuestStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig questConfig)
        {
            var questId = questConfig.Id;
            var questView = _questObjectViews.FirstOrDefault(value => value.Id == questConfig.Id);
            if (questView == null)
            {
                Debug.Log($"QuestConfigurator :: Start : Can't find view of quest {questId}");
                return null;
            }

            if (_questFactories.TryGetValue(questConfig.QuestType, out var factory))
            {
                var questModel = factory.Invoke();
                return new Quest(questView, questModel);
            }

            Debug.Log($"QuestConfigurator :: Start : Can't create model for quest {questId}");
            return null;
        }

        #endregion
    }
}