﻿namespace iTrendz.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{City ?? ""}, {State ?? ""}, {Country}";
    }
}