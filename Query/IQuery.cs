namespace SqlHelper.Query
{
    public interface IQuery : ISqlConvertible
    {
        Table Table { get; }
    }
}
