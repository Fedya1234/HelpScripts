namespace StateMashine.Conditions
{
    public class IsNot : ICondition
    {
        private ICondition _condition;

        public IsNot(ICondition condition)
        {
            _condition = condition;
        }

        public bool Execute()
        {
            return !_condition.Execute();
        }
    }
}