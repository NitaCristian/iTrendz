﻿namespace iTrendz.Domain.Models;

public class Media
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public Post Post { get; set; }
}