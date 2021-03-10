using System;


namespace JevLogin
{
    public interface IUserInputProxy 
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}