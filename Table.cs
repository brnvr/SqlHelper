using System.Collections.Generic;
using System.Data;
using SqlHelper.Exception;

namespace SqlHelper
{
    public class Table
    {
        public string Name { get; set; }
        List<Column> columns;

        public Table(string name, Column[] columns = null)
        {
            Name = name;
            this.columns = new List<Column>();

            if (columns != null)
            {
                AddColumns(columns);
            }
        }

        public void AddColumn(Column column)
        {
            if (ContainsColumn(column.Name))
            {
                throw new DuplicateColumnException(this, column.Name);
            }

            columns.Add(column);
        }

        public void AddColumns(Column[] columns)
        {
            foreach (Column column in columns)
            {
                AddColumn(column);
            }
        }

        public bool ContainsColumn(string name)
        {
            return ColumnIndex(name) != -1;
        }

        public int ColumnIndex(string name)
        {
            return columns.FindIndex((Column column) => { return column.Name == name; });
        }

        public Column Column(string name)
        {
            return columns.Find((Column column) => { return column.Name == name; });
        }

        public Column Column(int index)
        {
            return columns[index];
        }

        public List<string> ColumnNames()
        {
            return columns.ConvertAll(column => column.Name);
        }

        public List<object> ColumnValues()
        {
            return columns.ConvertAll(column => column.Value);
        }

        public void SetValuesFromDataTable(DataTable dataTable, int index)
        {
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                Column column;

                column = Column(dataColumn.ColumnName);
                column.SetValueFromDataTable(dataTable, index);
            }
        }
    }
}
