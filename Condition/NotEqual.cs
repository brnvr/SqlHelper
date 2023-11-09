using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class NotEqual : Comparator
    {
        public NotEqual(Table table0, string columnName0, Table table1, string columnName1) : base(table0, columnName0, table1, columnName1, Comparison.NotEqual) { }
        public NotEqual(Table table, string columnName, object value) : base(table, columnName, value, Comparison.NotEqual) { }
        public NotEqual(object value, Table table, string columnName) : base(value, table, columnName, Comparison.NotEqual) { }
        public NotEqual(IQuery query0, string columnName0, IQuery query1, string columnName1) : base(query0, columnName0, query1, columnName1, Comparison.NotEqual) { }
        public NotEqual(IQuery query, string columnName, object value) : base(query, columnName, value, Comparison.NotEqual) { }
        public NotEqual(object value, IQuery query, string columnName) : base(value, query, columnName, Comparison.NotEqual) { }
        public NotEqual(object value0, object value1) : base(value0, value1, Comparison.NotEqual) { }
    }
}
