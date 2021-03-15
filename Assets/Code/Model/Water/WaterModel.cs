namespace JevLogin
{
    public sealed class WaterModel
    {
        public WaterStruct WaterStruct;
        public WaterSettingsData PlayerSettingsData;

        public WaterModel(WaterStruct playerStruct, WaterSettingsData playerSettings)
        {
            WaterStruct = playerStruct;
            PlayerSettingsData = playerSettings;
        }
    }
}