namespace TodoApi.Models;

public class GuruItem{
    public long Id { get; set; }
    public string? Nip { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
}