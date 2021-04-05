using UnityEngine;


namespace JevLogin
{
    public sealed class QuestObjectView : LevelObjectView
    {
        #region Fields

        [SerializeField] private int _id;
        [SerializeField] private Color _completedColor;

        private Color _defaultColor;

        #endregion


        #region Properties

        public int Id => _id;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }

        #endregion


        #region Methods

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }

        #endregion
    }
}