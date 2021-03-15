using UnityEngine;

namespace JevLogin
{
    public class PlayerMoveController : IFixedExecute, ICleanup, IExecute
    {
        #region Fields

        private PlayerModel _playerModel;
        private readonly ContactPooler _contactPooler;

        private IUserInputProxy _inputHorizontal;
        private IUserInputProxy _inputVertical;

        private float _speed;
        private float _horizontal;
        private float _vertical;
        private float _newVelocity = 0.0f;

        #endregion


        #region ClassLifeCycles

        public PlayerMoveController(PlayerModel playerModel,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) inputProxy, float walkSpeed, ContactPooler contactPooler)
        {
            _playerModel = playerModel;
            _inputHorizontal = inputProxy.inputHorizontal;
            _inputVertical = inputProxy.inputVertical;
            _contactPooler = contactPooler;

            _speed = walkSpeed;

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

        public void FixedExecute(float fixedDeltaTime)
        {
            var speed = fixedDeltaTime * _speed;
            _playerModel.PlayerStruct.DoJump = _vertical > 0;

            var Walking = Mathf.Abs(_horizontal) > _playerModel.PlayerStruct.MovingThrash;

            _newVelocity = 0.0f;

            if (Walking)
            {
                if ((_horizontal > 0 || !_contactPooler.HasLeftContact) && (_horizontal < 0 || !_contactPooler.HasRightContact))
                {
                    _newVelocity = speed * _horizontal;
                    _playerModel.PlayerComponents.TransformPlayer.localScale = _horizontal < 0 ?
                        _playerModel.PlayerStruct.LeftScale : _playerModel.PlayerStruct.RightScale;
                    //_playerModel.PlayerStruct.AnimState = AnimState.Run;
                }
                else if ((_horizontal > 0 || _contactPooler.HasLeftContact) && (_horizontal < 0 || _contactPooler.HasRightContact))
                {
                    _playerModel.PlayerComponents.TransformPlayer.localScale = _horizontal < 0 ?
                        _playerModel.PlayerStruct.LeftScale : _playerModel.PlayerStruct.RightScale;
                    //_playerModel.PlayerStruct.AnimState = AnimState.Idle;
                }
            }
            //else
            //{
            //    _playerModel.PlayerStruct.AnimState = AnimState.Idle;
            //    //TODO перейти на события
            //    if (Input.GetButton(ManagerAxis.FIRE1))
            //    {
            //        _playerModel.PlayerStruct.AnimState = AnimState.AttackMidleOne;
            //    }
            //    else if (Input.GetButton(ManagerAxis.FIRE2))
            //    {
            //        _playerModel.PlayerStruct.AnimState = AnimState.AttackMidleTwo;
            //    }
            //}

            _playerModel.PlayerComponents.RigidbodyPlayer.velocity = _playerModel.PlayerComponents.RigidbodyPlayer.velocity.Change(x: _newVelocity);

            if (_contactPooler.IsGrounded && _playerModel.PlayerStruct.DoJump &&
                Mathf.Abs(_playerModel.PlayerComponents.RigidbodyPlayer.velocity.y) <= _playerModel.PlayerStruct.JumpTresh)
            {
                _playerModel.PlayerComponents.RigidbodyPlayer.AddForce(Vector2.up * _playerModel.PlayerStruct.JumpForce, ForceMode2D.Impulse);
            }
            //else if (Mathf.Abs(_playerModel.PlayerComponents.RigidbodyPlayer.velocity.y) > _playerModel.PlayerStruct.FlyThresh)
            //{
            //    _playerModel.PlayerStruct.AnimState = AnimState.Jump;
            //}
        }

        #endregion

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _speed;
            _playerModel.PlayerStruct.DoJump = _vertical > 0;

            var Walking = Mathf.Abs(_horizontal) > _playerModel.PlayerStruct.MovingThrash;

            _newVelocity = 0.0f;

            if (Walking)
            {
                if ((_horizontal > 0 || !_contactPooler.HasLeftContact) && (_horizontal < 0 || !_contactPooler.HasRightContact))
                {
                    if (_playerModel.PlayerStruct.AnimState != AnimState.Run)
                    {
                        _playerModel.PlayerStruct.AnimState = AnimState.Run;
                    }
                }
                else if ((_horizontal > 0 || _contactPooler.HasLeftContact) && (_horizontal < 0 || _contactPooler.HasRightContact))
                {
                    if (_playerModel.PlayerStruct.AnimState != AnimState.Idle)
                    {
                        _playerModel.PlayerStruct.AnimState = AnimState.Idle; 
                    }
                }
            }
            else
            {
                _playerModel.PlayerStruct.AnimState = AnimState.Idle;
                if (Input.GetButton(ManagerAxis.FIRE1))
                {
                    _playerModel.PlayerStruct.AnimState = AnimState.AttackMidleOne;
                }
                else if (Input.GetButton(ManagerAxis.FIRE2))
                {
                    _playerModel.PlayerStruct.AnimState = AnimState.AttackMidleTwo;
                }
            }

            if (Mathf.Abs(_playerModel.PlayerComponents.RigidbodyPlayer.velocity.y) > _playerModel.PlayerStruct.FlyThresh)
            {
                _playerModel.PlayerStruct.AnimState = AnimState.Jump;
            }
        }

        #region ICleanup

        public void Cleanup()
        {
            _inputHorizontal.AxisOnChange -= _inputHorizontal_AxisOnChange;
            _inputVertical.AxisOnChange -= _inputVertical_AxisOnChange;
        }



        #endregion
    }
}