using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class InQuery : ICondition
    {
        string value;
        SelectQuery subquery;

        public InQuery(object value, SelectQuery subquery)
        {
            this.value = value.ToString();
            this.subquery = subquery;
        }

        public InQuery(IQuery query, string columnName, SelectQuery subquery)
        {
            value = query.Table.Name + "." + columnName;
            this.subquery = subquery;
        }

        public string ToSql()
        {
            return value.ToString() + " IN (" + subquery.ToSql() + ")";
        }
    }
}
