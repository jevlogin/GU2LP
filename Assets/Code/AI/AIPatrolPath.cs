using Pathfinding;
using System;


namespace JevLogin
{
    public class AIPatrolPath : AIPath
    {
        public new event EventHandler TargetReached = delegate (object sender, EventArgs e) { };

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReached.Invoke(this, EventArgs.Empty);
        }
    }
}