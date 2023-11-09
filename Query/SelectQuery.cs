using SqlHelper.Exception;
using System.Collections.Generic;

namespace SqlHelper.Query
{
    public class SelectQuery : Query, ISqlConvertible
    {
        List<Order> order { get; }

        protected int Offset { get; set; }
        protected int Fetch { get; set; }
        protected bool Distinct { get; set; }
        
        protected List<JoinQuery> Joined { get; }

        public SelectQuery(Table table, List<string> columnNames) : base(table, columnNames)
        {
            order = new List<Order>();
            Joined = new List<JoinQuery>();
        }

        public SelectQuery(Table table, bool includeAllColumns) : base(table, includeAllColumns)
        {
            order = new List<Order>();
            Joined = new List<JoinQuery>();
        }

        public void Order(Order ord)
        {
            order.Add(ord);
        }

        public void Order(string columnName, Ordering ordering = Ordering.Asc)
        {
            order.Add(new Order(Table.Column(columnName), ordering));
        }

        public void Join(JoinQuery join)
        {
            Joined.Add(join);
        }

        public int TotalColumnsCount()
        {
            int count;

            count = 0;

            count += ColumnsCount();

            foreach (JoinQuery join in Joined)
            {
                count += join.ColumnsCount();
            }

            return count;
        }

        public override string ToSql()
        {
            string query;

            if (TotalColumnsCount() == 0)
            {
                throw new QueryEmptyException(this);
            }

            query = "SELECT ";

            if (Distinct)
            {
                query += "DISTINCT ";
            }

            {
                List<string> columns;

                columns = ColumnNames().ConvertAll((string columnName) =>
                {
                    string alias;

                    alias = ColumnAlias(columnName);

                    return Table.Name + "." + columnName + (alias == null ? "" : " as " + alias);
                });

                query += string.Join(", ", columns);
            }

            foreach (JoinQuery join in Joined)
            {
                if (join.ColumnsCount() > 0)
                {
                    query += ", ";

                    List<string> columns;

                    columns = join.ColumnNames().ConvertAll((string columnName) =>
                    {
                        string alias;

                        alias = join.ColumnAlias(columnName);

                        return join.Table.Name + "." + columnName + (alias == null ? "" : " as " + alias);
                    });

                    query += string.Join(", ", columns);
                }
            }

            query += " FROM " + Table.Name + " ";

            foreach (JoinQuery join in Joined)
            {
                query += join.ToSql();
            }

            query += ProccessConditions();

            if (order.Count > 0)
            {
                query += $"ORDER BY ";
            }

            for (int i = 0; i < order.Count; i++)
            {
                Order ord;

                ord = order[i];

                query += ord.Orderer.Name + " " + ord.Ordering.ToString();

                if (i < order.Count - 1)
                {
                    query += ",";
                }

                query += " ";
            }

            if (Offset > 0)
            {
                query += $"OFFSET { Offset.ToString() } rows ";
            }

            if (Fetch > 0)
            {
                query += $"FETCH next { Fetch.ToString() } rows only ";
            }

            return query;
        }
    }
}
