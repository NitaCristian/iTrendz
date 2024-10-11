namespace iTrendz.Domain.Models;

public class Transaction
{
    public int Id { get; set; }
    public Campaign Campaign { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}