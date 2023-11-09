using SqlHelper.Exception;
using System;
using System.Collections.Generic;

namespace SqlHelper.Query
{
    public class UpdateQuery : Query
    {
        public UpdateQuery(Table table, List<string> columnNames) : base(table, columnNames) { }

        public UpdateQuery(Table table, bool includeAllColumns) : base(table, includeAllColumns) { }

        public override string ToSql()
        {
            string query;

            query = "UPDATE " + Table.Name;

            query += " SET ";
        
            if (ColumnsCount() == 0)
            {
                throw new QueryEmptyException(this);
            }
            else
            {
                int nColumns;

                nColumns = ColumnsCount();

                for (int i = 0; i < nColumns; i++)
                {
                    object value;

                    value = ColumnValue(i);

                    if (value == null)
                    {
                        throw new ArgumentNullException("Column.value");
                    }

                    query += Table.Name + "." + ColumnName(i) + " = " + value.ToString();

                    if (i < nColumns - 1)
                    {
                        query += ",";
                    }

                    query += " ";
                }
            }

            query += ProccessConditions();

            return query;
        }
    }
}