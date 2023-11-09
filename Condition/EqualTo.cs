using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class EqualTo : Comparator
    {
        public EqualTo(Table table0, string columnName0, Table table1, string columnName1) : base(table0, columnName0, table1, columnName1) { }
        public EqualTo(Table table, string columnName, object value) : base(table, columnName, value) { }
        public EqualTo(object value, Table table, string columnName) : base(value, table, columnName) { }
        public EqualTo(IQuery query0, string columnName0, IQuery query1, string columnName1) : base(query0, columnName0, query1, columnName1) { }
        public EqualTo(IQuery query, string columnName, object value) : base(query, columnName, value) { }
        public EqualTo(object value, IQuery query, string columnName) : base(value, query, columnName) { }
        public EqualTo(object value0, object value1) : base(value0, value1) { }
    }
}
