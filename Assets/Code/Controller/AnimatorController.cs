using UnityEngine;


namespace JevLogin
{
    internal class AnimatorController : IExecute, ICleanup
    {
        #region Fields

        private SpriteAnimatorController _playerAnimatorController;
        private ContactPooler _contactPooler;
        private PlayerModel _playerModel;

        private IUserInputProxy _inputHorizontal;
        private IUserInputProxy _inputVertical;

        private float _horizontal;
        private float _vertical;

        #endregion


        #region ClassLifeCycles

        public AnimatorController(ContactPooler contactPoolerPlayer,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) inputProxy,
            PlayerModel playerModel,
            SpriteAnimatorController spritePlayerAnimatorController)
        {
            _contactPooler = contactPoolerPlayer;
            _inputHorizontal = inputProxy.inputHorizontal;
            _inputVertical = inputProxy.inputVertical;
            _playerModel = playerModel;
            _playerAnimatorController = spritePlayerAnimatorController;

            _inputHorizontal.AxisOnChange += _inputHorizontal_AxisOnChange;
            _inputVertical.AxisOnChange += _inputVertical_AxisOnChange;
        }

        #endregion


        #region Methods

        private void _inputVertical_AxisOnChange(float value)
        {
            _vertical = value;
        }

        private void _inputHorizontal_AxisOnChange(float value)
        {
            _horizontal = value;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            switch (_playerModel.PlayerStruct.AnimState)
            {
                case AnimState.Idle:
                    _playerAnimatorController.StartAnimation(_playerModel.PlayerComponents.SpriteRenderer,
                        AnimState.Idle, true, _playerModel.PlayerStruct.AnimationSpeed);
                    break;
                case AnimState.Run:
                    _playerAnimatorController.StartAnimation(_playerModel.PlayerComponents.SpriteRenderer,
                       AnimState.Run, true, _playerModel.PlayerStruct.AnimationSpeed);
                    break;
                case AnimState.Jump:
                    _playerAnimatorController.StartAnimation(_playerModel.PlayerComponents.SpriteRenderer,
                       AnimState.Jump, true, _playerModel.PlayerStruct.AnimationSpeed);
                    break;
                case AnimState.AttackMidleOne:
                    _playerAnimatorController.StartAnimation(_playerModel.PlayerComponents.SpriteRenderer,
                       AnimState.AttackMidleOne, true, _playerModel.PlayerStruct.AnimationSpeed);
                    break;
                case AnimState.AttackMidleTwo:
                    _playerAnimatorController.StartAnimation(_playerModel.PlayerComponents.SpriteRenderer,
                       AnimState.AttackMidleTwo, true, _playerModel.PlayerStruct.AnimationSpeed);
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region iCleanup

        public void Cleanup()
        {
            _inputHorizontal.AxisOnChange -= _inputHorizontal_AxisOnChange;
            _inputVertical.AxisOnChange -= _inputVertical_AxisOnChange;
        }

        #endregion
    }
}