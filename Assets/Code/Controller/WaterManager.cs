using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal class WaterManager : IEmptyInitialization
    {
        private PlayerModel _playerModel;
        private float _animationSpeed;
        private List<SpriteAnimatorController> _listSpriteAnimatorControllerWater;
        private List<WaterView> _listWaterViews;


        public WaterManager(PlayerModel playerModel, List<SpriteAnimatorController> listSpriteAnimatorControllerWater, List<WaterView> listWaterViews)
        {
            _playerModel = playerModel;
            _animationSpeed = playerModel.PlayerStruct.AnimationSpeed;
            _listSpriteAnimatorControllerWater = listSpriteAnimatorControllerWater;
            _listWaterViews = listWaterViews;


            for (int i = 0; i < _listSpriteAnimatorControllerWater.Count; i++)
            {
                for (int j = 0; j < _listWaterViews.Count; j++)
                {
                    for (int k = 0; k < _listWaterViews[i].spriteRenderers.Count; k++)
                    {
                        _listSpriteAnimatorControllerWater[i].
                            StartAnimation(_listWaterViews[i].spriteRenderers[k], AnimState.Run, true, _animationSpeed);
                    }
                }
            }
        }
    }
}