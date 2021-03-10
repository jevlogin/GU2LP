namespace JevLogin
{
    public class InputController : IExecute
    {
        #region Fields

        private IUserInputProxy _inputHorizontal;
        private IUserInputProxy _inputVertical;

        private IUserInputMouseBool _inputFire1;
        private IUserInputMouseBool _inputFire2;

        #endregion


        #region ClassLifeCycles

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) inputProxy,
            (IUserInputMouseBool inputFire1, IUserInputMouseBool inputFire2) inputMouse)
        {
            _inputHorizontal = inputProxy.inputHorizontal;
            _inputVertical = inputProxy.inputVertical;

            _inputFire1 = inputMouse.inputFire1;
            _inputFire2 = inputMouse.inputFire2;
        }

        #endregion


        #region IIExecute

        public void Execute(float deltaTime)
        {
            _inputHorizontal.GetAxis();
            _inputVertical.GetAxis();

            _inputFire1.GetMouseButtonDown();
            _inputFire2.GetMouseButtonDown();
        }

        #endregion
    }
}