namespace JevLogin
{
    public interface IFixedExecute : IController
    {
        void FixedExecute(float fixedDeltaTime);
    }
}