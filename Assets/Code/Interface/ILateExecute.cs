namespace JevLogin
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}