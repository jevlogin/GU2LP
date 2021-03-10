using System.Collections.Generic;

namespace JevLogin
{
    public sealed class Controllers : IInitialization, IExecute, IFixedExecute, ICleanup, ILateExecute
    {
        #region Fields

        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<ICleanup> _cleanupControllers;

        #endregion


        #region ClassLifeCycles

        public Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<ILateExecute>();
            _fixedControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        #endregion


        #region Methods

        public Controllers Add(IController controller)
        {
            if (controller is IInitialization initialization)
            {
                _initializeControllers.Add(initialization);
            }
            if (controller is IFixedExecute fixedExecute)
            {
                _fixedControllers.Add(fixedExecute);
            }
            if (controller is IExecute execute)
            {
                _executeControllers.Add(execute);
            }
            if (controller is ICleanup cleanup)
            {
                _cleanupControllers.Add(cleanup);
            }
            if (controller is ILateExecute lateExecute)
            {
                _lateControllers.Add(lateExecute);
            }
            return this;
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            for (int index = 0; index < _cleanupControllers.Count; index++)
            {
                _cleanupControllers[index].Cleanup();
            }
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            for (int index = 0; index < _executeControllers.Count; index++)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        #endregion


        #region iFixedExecute

        public void FixedExecute(float deltaTime)
        {
            for (int index = 0; index < _fixedControllers.Count; index++)
            {
                _fixedControllers[index].FixedExecute(deltaTime);
            }
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            for (int index = 0; index < _initializeControllers.Count; index++)
            {
                _initializeControllers[index].Initialization();
            }
        }

        #endregion


        #region ILateExecute

        public void LateExecute(float deltaTime)
        {
            for (int index = 0; index < _lateControllers.Count; index++)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        #endregion
    }
}