using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStoreApi.Models;

public class BookDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }
    [Range(0, 999)]

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}