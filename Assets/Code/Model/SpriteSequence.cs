using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class SpriteSequence
    {
        public AnimState AnimState;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}