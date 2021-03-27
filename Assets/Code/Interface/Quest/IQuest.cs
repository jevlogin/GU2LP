using System;


namespace JevLogin
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}