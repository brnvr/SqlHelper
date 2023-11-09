namespace SqlHelper.Exception
{
    public class DuplicateColumnException : System.Exception
    {
        public DuplicateColumnException(Table table, string columnName, System.Exception innerException = null) : base(message(table, columnName), innerException)
        {

        }

        private static string message(Table table, string columnName)
        {
            return $"Column '{ columnName }' already exists in Table '{ table.Name }'.";
        }
    }
}
