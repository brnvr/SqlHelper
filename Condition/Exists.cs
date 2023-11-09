using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class Exists : ICondition
    {
        protected SelectQuery subquery;

        public Exists(SelectQuery subquery)
        {
            this.subquery = subquery;
        }

        public virtual string ToSql()
        {
            return $" Exists ( { subquery.ToSql() })";
        }
    }
}
