using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Animation : IExecute
    {
        #region Fields
        
        public List<Sprite> Sprites;
        public AnimState AnimState;

        public float Speed = 10;
        public float Counter = 0;
        public bool Loop = true;
        public bool Sleeps;

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            if (Sleeps)
            {
                return;
            }
            Counter += Time.deltaTime * Speed;

            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleeps = true;
            }
        } 

        #endregion
    }
}
