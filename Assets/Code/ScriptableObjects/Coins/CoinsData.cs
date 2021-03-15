using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "Data/CoinsData", order = 51)]
    public sealed class CoinsData : ScriptableObject
    {
        public AudioClip[] CoinPickingSounds;
    }
}