using System.Data;

namespace SqlHelper
{
    public class Column
    {
        public string Name { get; }
        public object Value { get; set; }

        public Column(string name, object value = null)
        {
            Name = name;

            if (value == null)
            {
                Value = ":" + name;
            }
            else
            {
                Value = value;
            }
        }

        public Column(string name, DataTable table, int index)
        {
            Name = name;

            Value = table.Rows[index][Name];
        }

        public void SetValueFromDataTable(DataTable table, int index)
        {
            Value = table.Rows[index][Name];
        }
    }
}
