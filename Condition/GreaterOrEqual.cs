using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class GreaterOrEqual : Comparator
    {
        public GreaterOrEqual(Table table0, string columnName0, Table table1, string columnName1) : base(table0, columnName0, table1, columnName1, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(Table table, string columnName, object value) : base(table, columnName, value, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(object value, Table table, string columnName) : base(value, table, columnName, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(IQuery query0, string columnName0, IQuery query1, string columnName1) : base(query0, columnName0, query1, columnName1, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(IQuery query, string columnName, object value) : base(query, columnName, value, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(object value, IQuery query, string columnName) : base(value, query, columnName, Comparison.GreaterOrEqual) { }
        public GreaterOrEqual(object value0, object value1) : base(value0, value1, Comparison.GreaterOrEqual) { }
    }
}
