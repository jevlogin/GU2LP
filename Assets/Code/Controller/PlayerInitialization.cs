namespace JevLogin
{
    internal class PlayerInitialization
    {
        #region Fields

        private PlayerFactory _playerFactory;
        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeCycles

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _playerModel = _playerFactory.CreatePlayerModel();
        }

        #endregion


        #region Methods

        public PlayerModel GetPlayerModel()
        {
            return _playerModel;
        }

        #endregion
    }
}