using SqlHelper.Exception;
using System.Collections.Generic;

namespace SqlHelper.Query
{
    public class JoinQuery : Query, ISqlConvertible
    {
        public Query query;
        public JoinType Type;

        public JoinQuery(Table table, List<string> columnNames, JoinType type) : base(table, columnNames)
        {
            Type = type;
        }

        public JoinQuery(Table table, bool includeAllColumns, JoinType type) : base(table, includeAllColumns)
        {
            Type = type;
        }

        public override string ToSql()
        {
            if (Conditions.Count == 0)
            {
                throw new JoinConditionsEmptyException(this);
            }

            return JoinTypeString() + " " + Table.Name + " " + ProccessConditions();
        }

        protected override string ProccessConditions()
        {
            return "ON " + ProccessConditions(Conditions);
        }

        public string JoinTypeString()
        {
            return JoinTypeString(Type);
        }

        public static string JoinTypeString(JoinType type)
        {
            switch (type)
            {
                case JoinType.LeftOuter:
                    return "LEFT OUTER JOIN";

                case JoinType.RightOuter:
                    return "RIGHT OUTER JOIN";

                case JoinType.FullOuter:
                    return "FULL OUTER JOIN";

                default:
                    return "INNER JOIN";
            }
        }
    }
}
