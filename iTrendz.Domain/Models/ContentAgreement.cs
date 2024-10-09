namespace iTrendz.Domain.Models;

public class ContentAgreement : ContentDetail
{
    public int Id { get; set; }
    public Contract Contract { get; set; }
}