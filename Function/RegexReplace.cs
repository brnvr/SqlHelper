namespace SqlHelper.Function
{
    public class RegexpReplace : IFunction
    {
        string source;
        string regex;
        string substring;

        public RegexpReplace(string source, string regex, string substring)
        {
            this.source = $"'{source}'";
            this.regex = $"'{regex}'";
            this.substring = $"'{substring}'";
        }

        public RegexpReplace(Table table, string columnName, string regex, string substring)
        {
            source = table.Name + "." + columnName;
            this.regex = $"'{regex}'";
            this.substring = $"'{substring}'";
        }

        public string ToSql()
        {
            return $"regexp_replace({source}, {regex}, {substring})";
        }
    }
}
