using System.Collections.Generic;
using System.Linq;

namespace SqlHelper.Condition
{
    public class Gate : ICondition
    {
        protected List<ICondition> conditions;
        public Logical Type;

        public Gate(Logical op)
        {
            Type = op;
        }

        public Gate(Logical op, List<ICondition> conditions)
        {
            Type = op;
            this.conditions = conditions;
        }

        public void AddCondition(ICondition condition)
        {
            conditions.Add(condition);
        }

        public string ToSql()
        {
            return "(" + string.Join($" {GateString(Type)} ", conditionsProcessed()) + ")";
        }

        public IEnumerable<string> conditionsProcessed()
        {
            return conditions.Select((ICondition condition) => { return condition.ToSql(); });
        }

        public string GateString()
        {
            return GateString(Type);
        }

        public static string GateString(Logical op)
        {
            return op.ToString();
        }
    }

    

    

    

    

    

    

    

    

    

    
}
