using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UAS.Models;

public class PresensiHarianGuru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    public string NIP { get; set; } = null!;
    [Required]
    public string Tgl { get; set; } = null!;
    [Required]
    public string Kehadiran { get; set; } = null!;
}