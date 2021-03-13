using System;
using System.Collections.Generic;
using System.Linq;


namespace JevLogin
{
    public sealed class WaterFactory : IEmptyInitialization
    {
        private WaterData _waterData;
        private WaterModel _waterModel;

        public WaterFactory(WaterData waterData)
        {
            _waterData = waterData;
        }

        public WaterModel GetWaterModel()
        {
            if (_waterModel == null)
            {
                var playerStruct = _waterData.WaterStruct;
                var playerSettings = _waterData.WaterSettingsData;


                foreach (var spriteAnimatorConfig in _waterData.WaterSettingsData.SpriteAnimatorConfigs)
                {
                    playerStruct.SpriteAnimatorControllers.Add(new SpriteAnimatorController(spriteAnimatorConfig));
                }

                _waterModel = new WaterModel(playerStruct, playerSettings);
            }

            return _waterModel;
        }
    }
}