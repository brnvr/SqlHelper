using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class NotExists : Exists
    {
        public NotExists(SelectQuery subquery) : base(subquery) { }

        public override string ToSql()
        {
            return " Not" + base.ToSql();
        }
    }
}
