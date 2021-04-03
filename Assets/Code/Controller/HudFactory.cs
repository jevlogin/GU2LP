using UnityEngine;

namespace JevLogin
{
    public sealed class HudFactory
    {
        private HudData _hudData;
        private HpView _hpView;

        public HudFactory(HudData hudData)
        {
            _hudData = hudData;
            Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

            _hpView = Object.Instantiate(_hudData.HpView, canvas.transform);
        }
    }
}