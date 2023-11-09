using SqlHelper.Exception;
using SqlHelper.Query;

namespace SqlHelper.Condition
{
    public class Comparator : ICondition
    {
        protected string value0, value1;
        public Comparison Type;

        protected Comparator(Comparison op)
        {
            Type = op;
        }

        public Comparator(IQuery query0, string columnName0, IQuery query1, string columnName1, Comparison op = Comparison.Equal)
        {
            if (!query0.Table.ContainsColumn(columnName0))
            {
                throw new ColumnNotFoundException(query0.Table, columnName0);
            }

            if (!query1.Table.ContainsColumn(columnName1))
            {
                throw new ColumnNotFoundException(query1.Table, columnName1);
            }

            Type = op;
            value0 = query0.Table.Name + "." + columnName0;
            value1 = query1.Table.Name + "." + columnName1;
        }

        public Comparator(Table table0, string columnName0, Table table1, string columnName1, Comparison op = Comparison.Equal)
        {
            if (!table0.ContainsColumn(columnName0))
            {
                throw new ColumnNotFoundException(table0, columnName0);
            }

            if (!table1.ContainsColumn(columnName1))
            {
                throw new ColumnNotFoundException(table1, columnName1);
            }

            Type = op;
            value0 = table0.Name + "." + columnName0;
            value1 = table1.Name + "." + columnName1;
        }

        public Comparator(object value0, object value1, Comparison op = Comparison.Equal)
        {
            this.value0 = value0.ToString();
            this.value1 = value1.ToString();

            Type = op;
        }

        public Comparator(IQuery query, string columnName, object value, Comparison op = Comparison.Equal)
        {
            if (!query.Table.ContainsColumn(columnName))
            {
                throw new ColumnNotFoundException(query.Table, columnName);
            }

            value0 = query.Table.Name + "." + columnName;
            value1 = value.ToString();
            Type = op;
        }

        public Comparator(Table table, string columnName0, object value, Comparison op = Comparison.Equal)
        {
            if (!table.ContainsColumn(columnName0))
            {
                throw new ColumnNotFoundException(table, columnName0);
            }

            value0 = table.Name + "." + columnName0;
            value1 = value.ToString();
            Type = op;
        }

        public Comparator(object value, IQuery query, string columnName, Comparison op = Comparison.Equal)
        {
            if (!query.Table.ContainsColumn(columnName))
            {
                throw new ColumnNotFoundException(query.Table, columnName);
            }

            value0 = value.ToString();
            value1 = query.Table.Name + "." + columnName;
            Type = op;
        }

        public Comparator(object value, Table table, string columnName, Comparison op = Comparison.Equal)
        {
            if (!table.ContainsColumn(columnName))
            {
                throw new ColumnNotFoundException(table, columnName);
            }

            value0 = value.ToString();
            value1 = table.Name + "." + columnName;
            Type = op;
        }

        public static Comparator Equal(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1); }
        public static Comparator Equal(Table table, string columnName, object value) { return new Comparator(table, columnName, value); }
        public static Comparator Equal(object value, Table table, string columnName) { return new Comparator(value, table, columnName); }
        public static Comparator Equal(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1); }
        public static Comparator Equal(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value); }
        public static Comparator Equal(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName); }
        public static Comparator Equal(object value0, object value1) { return new Comparator(value0, value1); }

        public static Comparator Greater(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.Greater); }
        public static Comparator Greater(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.Greater); }
        public static Comparator Greater(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.Greater); }
        public static Comparator Greater(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.Greater); }
        public static Comparator Greater(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.Greater); }
        public static Comparator Greater(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.Greater); }
        public static Comparator Greater(object value0, object value1) { return new Comparator(value0, value1, Comparison.Greater); }

        public static Comparator Less(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.Less); }
        public static Comparator Less(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.Less); }
        public static Comparator Less(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.Less); }
        public static Comparator Less(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.Less); }
        public static Comparator Less(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.Less); }
        public static Comparator Less(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.Less); }
        public static Comparator Less(object value0, object value1) { return new Comparator(value0, value1, Comparison.Less); }

        public static Comparator GreaterOrEqual(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.GreaterOrEqual); }
        public static Comparator GreaterOrEqual(object value0, object value1) { return new Comparator(value0, value1, Comparison.GreaterOrEqual); }

        public static Comparator LessOrEqual(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.LessOrEqual); }
        public static Comparator LessOrEqual(object value0, object value1) { return new Comparator(value0, value1, Comparison.LessOrEqual); }

        public static Comparator Is(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.Is); }
        public static Comparator Is(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.Is); }
        public static Comparator Is(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.Is); }
        public static Comparator Is(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.Is); }
        public static Comparator Is(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.Is); }
        public static Comparator Is(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.Is); }
        public static Comparator Is(object value0, object value1) { return new Comparator(value0, value1, Comparison.Is); }

        public static Comparator NotEqual(Table table0, string columnName0, Table table1, string columnName1) { return new Comparator(table0, columnName0, table1, columnName1, Comparison.NotEqual); }
        public static Comparator NotEqual(Table table, string columnName, object value) { return new Comparator(table, columnName, value, Comparison.NotEqual); }
        public static Comparator NotEqual(object value, Table table, string columnName) { return new Comparator(value, table, columnName, Comparison.NotEqual); }
        public static Comparator NotEqual(IQuery query0, string columnName0, IQuery query1, string columnName1) { return new Comparator(query0, columnName0, query1, columnName1, Comparison.NotEqual); }
        public static Comparator NotEqual(IQuery query, string columnName, object value) { return new Comparator(query, columnName, value, Comparison.NotEqual); }
        public static Comparator NotEqual(object value, IQuery query, string columnName) { return new Comparator(value, query, columnName, Comparison.NotEqual); }
        public static Comparator NotEqual(object value0, object value1) { return new Comparator(value0, value1, Comparison.NotEqual); }

        public string ToSql()
        {
            return $"{value0} {ComparatorString()} {value1}";
        }

        public string ComparatorString()
        {
            return ComparatorString(Type);
        }

        public static string ComparatorString(Comparison op)
        {
            switch (op)
            {
                case Comparison.Greater:
                    return ">";

                case Comparison.Less:
                    return "<";

                case Comparison.GreaterOrEqual:
                    return ">=";

                case Comparison.LessOrEqual:
                    return "<=";

                case Comparison.NotEqual:
                    return "<>";

                case Comparison.Is:
                    return "is";

                default:
                    return "=";
            }
        }
    }
}
