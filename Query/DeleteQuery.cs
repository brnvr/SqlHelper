namespace SqlHelper.Query
{
    public class DeleteQuery : Query, ISqlConvertible
    {
        public DeleteQuery(Table table) : base(table, false) { }

        public override string ToSql()
        {
            string query;

            query = "DELETE FROM " + Table.Name + " ";

            query += ProccessConditions();

            return query;
        }
    }
}
