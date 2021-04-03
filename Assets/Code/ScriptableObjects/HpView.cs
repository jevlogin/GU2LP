using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class HpView : MonoBehaviour
    {
        private IHpViewModel _hpViewModel;
        [SerializeField] private List<Sprite> _spriteRenderers = new List<Sprite>();
        [SerializeField] private Sprite _lostLife;
    }
}