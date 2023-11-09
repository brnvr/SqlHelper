using SqlHelper.Query;

namespace SqlHelper.Exception
{
    public class EntryNotFoundException : System.Exception
    {
        public EntryNotFoundException(Table table, System.Exception innerException = null) : base(message(table), innerException)
        {
            
        }

        private static string message(Table table)
        {
            return $"Entry not found in table { table.Name }.";
        }
    }
}
