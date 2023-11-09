using SqlHelper.Exception;
using System;
using System.Collections.Generic;

namespace SqlHelper.Query
{
    public class InsertQuery : Query, ISqlConvertible
    {
        public InsertQuery(Table table, List<string> columnNames) : base(table, columnNames) { }

        public InsertQuery(Table table, bool includeAllColumns) : base(table, includeAllColumns) { }

        public override string ToSql()
        {
            string query;

            query = "INSERT INTO " + Table.Name + " (";

            if (ColumnsCount() == 0)
            {
                throw new QueryEmptyException(this);
            }
            else
            {
                int nColumns;

                nColumns = ColumnsCount();

                query += string.Join(", ", ColumnNames());
                query += ") VALUES (";

                for (int i = 0; i < nColumns; i++)
                {
                    object value;

                    value = ColumnValue(i);

                    if (value == null)
                    {
                        throw new ArgumentNullException("Column.value");
                    }

                    query += value.ToString();

                    if (i < nColumns - 1)
                    {
                        query += ", ";
                    }
                }

                query += ")";
            }

            return query;
        }
    }
}
