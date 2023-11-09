namespace SqlHelper.Exception
{
    public class ColumnNotFoundException : System.Exception
    {
        public ColumnNotFoundException(Table table, string columnName, System.Exception innerException = null) : base(messageTable(table, columnName), innerException)
        {
            Data.Add("Table object", table);
        }


        private static string messageTable(Table table, string columnName)
        {
            return $"Column '{ columnName }' was not found in Table '{ table.Name }'.";
        }

        private static string messageQueryContent(string columnName)
        {
            return $"Column '{ columnName }' was not found in QueryContent.";
        }
    }
}
