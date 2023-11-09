using SqlHelper.Query;

namespace SqlHelper.Exception
{
    public class JoinConditionsEmptyException : System.Exception
    {
        public JoinConditionsEmptyException(JoinQuery join, System.Exception innerException = null) : base(message, innerException)
        {

        }

        private static string message = "A Joined QueryContent must have at least one condition.";
    }
}
