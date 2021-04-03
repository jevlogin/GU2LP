using UnityEngine;

namespace JevLogin
{
    [CreateAssetMenu(fileName = "HudData", menuName = "Data/HudData", order = 51)]
    public sealed class HudData : ScriptableObject
    {
        [SerializeField] private HpView _hpView;
        //[SerializeField] private ScoreView _scoreView;

        public HpView HpView { get => _hpView; }
        //public ScoreView ScoreView { get => _scoreView; }
    }
}