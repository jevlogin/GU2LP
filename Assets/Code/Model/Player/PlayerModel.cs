namespace JevLogin
{
    public sealed class PlayerModel
    {
        public PlayerStruct PlayerStruct;
        public PlayerComponents PlayerComponents;
        public PlayerSettingsData PlayerSettings;

        public PlayerModel(PlayerStruct playerStruct, PlayerComponents playerComponents, PlayerSettingsData playerSettings)
        {
            PlayerStruct = playerStruct;
            PlayerComponents = playerComponents;
            PlayerSettings = playerSettings;
        }
    }
}