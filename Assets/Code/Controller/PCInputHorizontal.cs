using System;
using UnityEngine;


namespace JevLogin
{
    public class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float value) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(ManagerAxis.HORIZONTAL));
        }
    }
}