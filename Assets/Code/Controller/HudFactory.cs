using UnityEngine;

namespace JevLogin
{
    public sealed class HudFactory
    {
        private readonly HudData _hudData;
        private readonly HpView _hpView;

        public HudFactory(HudData hudData)
        {
            _hudData = hudData;
            Canvas canvas = Object.FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                canvas = new GameObject("CanvasHUD").GetOrAddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.worldCamera = Camera.main;
            }
            _hpView = Object.Instantiate(_hudData.HpView, canvas.transform);
        }

        public HpView HpView { get => _hpView; }
    }
}