namespace SqlHelper.Function
{
    public class ToDate : IFunction
    {
        string date, format;

        public ToDate(string date, string format)
        {
            this.date = $"'{date}'";
            this.format = $"'{format}'";
        }

        public string ToSql()
        {
            return $"to_date({date}, {format})";
        }
    }
}
