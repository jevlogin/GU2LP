using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public class HpView : MonoBehaviour
    {
        public IHpViewModel _hpViewModel;
        [SerializeField] private Sprite _emptyHeart;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private List<Image> _lifes = new List<Image>();
        private float _defaultLifesMax;

        public void Initialize(HpViewModel hpViewModel)
        {
            _hpViewModel = hpViewModel;
            _defaultLifesMax = hpViewModel.HpModel.MaxHp;
            _hpViewModel.OnHpChange += OnHpChange;
        }

        private void OnHpChange(float currentHp)
        {
            var index = (int)_hpViewModel.HpModel.CurrentHp;
            if (index >= 0 && index < _hpViewModel.HpModel.MaxHp)
            {
                _lifes[(int)index].sprite = _emptyHeart;
            }
        }

        ~HpView()
        {
            _hpViewModel.OnHpChange -= OnHpChange;
        }

        public void RestartViewHp()
        {
            _hpViewModel.HpModel.CurrentHp = _defaultLifesMax;
            for (int i = 0; i < _defaultLifesMax; i++)
            {
                _lifes[i].sprite = _fullHeart;
            }
        }
    }
}