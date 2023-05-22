using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStoreApi{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public User(string userName, string password)
        {
            UserName=userName;
            Password=password;
        }
    }
};