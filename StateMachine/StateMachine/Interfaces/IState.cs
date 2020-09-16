namespace StateMashine
{
    public interface IState
    {
        State Execute();
        bool IsSelect();
    }
}

