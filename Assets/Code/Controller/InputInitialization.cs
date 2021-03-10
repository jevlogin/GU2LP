namespace JevLogin
{
    public class InputInitialization : IEmptyInitialization
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputMouseBool _mouseInputButtonDownFire1;
        private IUserInputMouseBool _mouseInputButtonDownFire2;

        #endregion


        #region ClassLifeCycles

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();

            _mouseInputButtonDownFire1 = new PCInputMouseFire1();
            _mouseInputButtonDownFire2 = new PCInputMouseFire2();
        }

        #endregion


        #region Methods

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInputProxy()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public (IUserInputMouseBool inputFire1, IUserInputMouseBool inputFire2) GetInputMouse()
        {
            (IUserInputMouseBool inputFire1, IUserInputMouseBool inputFire2) result = (_mouseInputButtonDownFire1, _mouseInputButtonDownFire2);
            return result;
        }

        #endregion
    }
}