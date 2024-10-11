namespace iTrendz.Domain.Models;

public class Contract
{
    public int Id { get; set; }
    public string Details { get; set; }
    public DateOnly SignedOnDate { get; set; }
    public ContractState State { get; set; }
    public Influencer Influencer { get; set; }
    public Campaign Campaign { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<ContentAgreement> AgreedContent { get; set; }
}