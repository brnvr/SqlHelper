namespace SqlHelper.Exception
{
    public class QueryEmptyException : System.Exception
    {
        public QueryEmptyException(Query.Query query, System.Exception innerException = null) : base(message, innerException)
        {
        }

        private static string message = "Query must have at least one column.";
    }
}
