namespace test.webapi.DTOs
{
    public class TransactionCreateDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
