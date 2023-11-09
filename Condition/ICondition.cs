namespace SqlHelper.Condition
{
    public enum Comparison
    {
        Equal,
        Greater,
        Less,
        GreaterOrEqual,
        LessOrEqual,
        NotEqual,
        Is
    }

    public enum Logical
    {
        And,
        Or
    }

    public interface ICondition : ISqlConvertible { }
}
