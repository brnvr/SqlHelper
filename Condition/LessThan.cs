using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class LessThan : Comparator
    {
        public LessThan(Table table0, string columnName0, Table table1, string columnName1) : base(table0, columnName0, table1, columnName1, Comparison.Less) { }
        public LessThan(Table table, string columnName, object value) : base(table, columnName, value, Comparison.Less) { }
        public LessThan(object value, Table table, string columnName) : base(value, table, columnName, Comparison.Less) { }
        public LessThan(IQuery query0, string columnName0, IQuery query1, string columnName1) : base(query0, columnName0, query1, columnName1, Comparison.Less) { }
        public LessThan(IQuery query, string columnName, object value) : base(query, columnName, value, Comparison.Less) { }
        public LessThan(object value, IQuery query, string columnName) : base(value, query, columnName, Comparison.Less) { }
        public LessThan(object value0, object value1) : base(value0, value1, Comparison.Less) { }
    }
}
