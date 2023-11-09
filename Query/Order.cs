namespace SqlHelper.Query
{
    public class Order
    {
        public Column Orderer { get; set; }
        public Ordering Ordering { get; set; }

        public Order(Column orderer, Ordering ordering)
        {
            Orderer = orderer;
            Ordering = ordering;
        }
    }
}
