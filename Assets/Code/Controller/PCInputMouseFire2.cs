using System;
using UnityEngine;


namespace JevLogin
{
    internal class PCInputMouseFire2 : IUserInputMouseBool
    {
        public event Action<bool> UserInputMouseBoolOnChange = delegate (bool value) { };

        public void GetMouseButtonDown()
        {
            UserInputMouseBoolOnChange.Invoke(Input.GetButtonDown(ManagerAxis.FIRE2));
        }
    }
}