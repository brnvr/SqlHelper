using SqlHelper.Condition;
using SqlHelper.Exception;
using System.Collections.Generic;

public enum Ordering
{
    Asc,
    Desc
}

public enum JoinType
{
    Inner,
    LeftOuter,
    RightOuter,
    FullOuter
}

namespace SqlHelper.Query
{
    public abstract class Query : IQuery
    {
        public Table Table { get; }
        protected List<int> ColumnIndexes { get; }
        protected Dictionary<string, string> ColumnAliases { get; }
        protected List<ICondition> Conditions { get; }

        public Query(Table table, List<string> columnNames)
        {
            Table = table;
            ColumnIndexes = new List<int>();
            Conditions = new List<ICondition>();
            ColumnAliases = new Dictionary<string, string>();

            if (columnNames != null)
            {
                IncludeColumns(columnNames, ColumnAliases);
            }
        }

        public Query(Table table, bool includeAllColumns)
        {
            Table = table;
            ColumnIndexes = new List<int>();
            Conditions = new List<ICondition>();
            ColumnAliases = new Dictionary<string, string>();

            if (includeAllColumns)
            {
                IncludeColumns(Table.ColumnNames());
            }
        }

        public void IncludeColumns(List<string> columnNames, Dictionary<string, string> aliases = null)
        {
            foreach (string columnName in columnNames)
            {
                string alias;

                alias = null;

                if (aliases != null)
                {
                    aliases.TryGetValue(columnName, out alias);
                }

                IncludeColumn(columnName, alias);
            }

        }

        public void IncludeColumn(string columnName, string alias = null)
        {
            int columnIndex;

            columnIndex = Table.ColumnIndex(columnName);

            if (columnIndex == -1)
            {
                throw new ColumnNotFoundException(Table, columnName);
            }

            ColumnIndexes.Add(columnIndex);
            SetColumnAlias(columnName, alias);
        }

        public int ColumnsCount()
        {
            return ColumnIndexes.Count;
        }

        public void SetColumnAlias(string columnName, string alias)
        {
            ColumnAliases[columnName] = alias;
        }

        public string ColumnAlias(string columnName)
        {
            string value;

            ColumnAliases.TryGetValue(columnName, out value);

            return value;
        }

        public string ColumnName(int index)
        {
            return Table.Column(ColumnIndexes[index]).Name;
        }

        public object ColumnValue(int index)
        {
            return Table.Column(ColumnIndexes[index]).Value;
        }

        public List<string> ColumnNames()
        {
            return ColumnIndexes.ConvertAll(i => Table.Column(i).Name);
        }

        public bool HasColumn(string columnName)
        {
            return ColumnNames().Contains(columnName);
        }

        public void AddCondition(ICondition condition)
        {
            Conditions.Add(condition);

        }

        protected static string ProccessConditions(List<ICondition> conditions)
        {
            if (conditions.Count != 0)
            {
                return new Gate(Logical.And, conditions).ToSql() + " ";
            }

            return "";
        }

        protected virtual string ProccessConditions()
        {
            string cond;

            cond = ProccessConditions(Conditions);

            if (string.IsNullOrEmpty(cond))
            {
                return "";
            }

            return "WHERE " + cond;
        }

        public abstract string ToSql();
    }
}
