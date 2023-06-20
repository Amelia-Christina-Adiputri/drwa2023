using UAS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS.Services;

public class KelasService
{
    private readonly IMongoCollection<KelasA> _kelasCollection;

    public KelasService(
        IOptions<KelasDatabaseSettings> KelasDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            KelasDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            KelasDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<KelasA>(
            KelasDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<KelasA>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<KelasA?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(KelasA newBook) =>
        await _kelasCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, KelasA updatedBook) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Id == id);
}