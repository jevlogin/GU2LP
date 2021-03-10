using System;
using UnityEngine;


namespace JevLogin
{
    public class PCInputMouseFire1 : IUserInputMouseBool
    {
        public event Action<bool> UserInputMouseBoolOnChange = delegate (bool value) { };

        public void GetMouseButtonDown()
        {
            UserInputMouseBoolOnChange.Invoke(Input.GetButtonDown(ManagerAxis.FIRE1));
        }
    }
}