namespace iTrendz.Domain.DTOs;

public class RefreshRequestDto
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}