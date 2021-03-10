using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "SpriteAnimatorConfig", menuName = "Data/SpriteAnimatorConfig", order = 51)]
    public sealed class SpriteAnimatorConfig : ScriptableObject
    {
        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();
    }
}