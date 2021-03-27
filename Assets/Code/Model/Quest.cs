using System;


namespace JevLogin
{
    public sealed class Quest : IQuest
    {
        #region Fields

        public event EventHandler<IQuest> Completed = delegate (object sender, IQuest quest) { };

        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;

        private bool _active;

        #endregion


        #region Properties

        public bool IsCompleted { get; private set; }

        #endregion


        #region ClassLifeCycles

        public Quest(QuestObjectView view, IQuestModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        #endregion


        #region Methods

        private void OnContact(LevelObjectView arg)
        {
            var completed = _model.TryComplete(arg.gameObject);
            if (completed)
            {
                Complete();
            }
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }
            _active = false;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed.Invoke(this, this);
        }

        #endregion


        #region IQuest

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }


        public void Reset()
        {
            if (_active)
            {
                return;
            }
            _active = true;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }

        #endregion
    }
}