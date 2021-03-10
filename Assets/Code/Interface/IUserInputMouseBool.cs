using System;


namespace JevLogin
{
    public interface IUserInputMouseBool 
    {
        event Action<bool> UserInputMouseBoolOnChange;
        void GetMouseButtonDown();
    }
}