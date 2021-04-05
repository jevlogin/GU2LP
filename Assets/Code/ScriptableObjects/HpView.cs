using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public class HpView : MonoBehaviour
    {
        public IHpViewModel _hpViewModel;
        [SerializeField] private Sprite _lostLife;
        [SerializeField] private List<Image> _lifes = new List<Image>();


        internal void Initialize(HpViewModel hpViewModel)
        {
            _hpViewModel = hpViewModel;
            _hpViewModel.OnHpChange += OnHpChange;
        }

        private void OnHpChange(float currentHp)
        {
            var index = (int)_hpViewModel.HpModel.CurrentHp;
            _lifes[(int)index].sprite = _lostLife;
        }

        ~HpView()
        {
            _hpViewModel.OnHpChange -= OnHpChange;
        }
    }
}