using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UAS.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    public string Nama { get; set; } = null!;
    [Required]
    public string Kelas { get; set; } = null!;
}