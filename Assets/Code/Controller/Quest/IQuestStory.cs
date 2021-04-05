using System;


namespace JevLogin
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}