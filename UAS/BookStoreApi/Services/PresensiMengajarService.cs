using UAS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _booksCollection;

    public PresensiMengajarService(
        IOptions<PresensiMengajarDatabaseSettings> PresensiMengajarDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PresensiMengajarDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PresensiMengajarDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            PresensiMengajarDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newBook) =>
        await _booksCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, PresensiMengajar updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}