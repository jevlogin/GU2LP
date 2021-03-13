namespace JevLogin
{
    public class WaterInitialization : IInitialization
    {
        #region Fields

        private readonly WaterModel _waterModel;
        private readonly Controllers _controller;

        #endregion


        #region ClassLifeCycles

        public WaterInitialization(WaterFactory waterFactory, Controllers controller)
        {
            _waterModel = waterFactory.GetWaterModel();
            _controller = controller;
        }

        #endregion


        #region Methods

        public WaterModel GetWaterModel()
        {
            return _waterModel;
        }

        public void Initialization()
        {
            for (int i = 0; i < _waterModel.WaterStruct.SpriteAnimatorControllers.Count; i++)
            {
                _controller.Add(_waterModel.WaterStruct.SpriteAnimatorControllers[i]);
            }
        }

        #endregion
    }
}