namespace StateMashine
{
    public interface IAction
    {
        void Start();
        bool Update();
        void Cancel();
    }
}
