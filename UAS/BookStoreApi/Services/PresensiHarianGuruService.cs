using UAS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresensiHarianGuru> _presensiHarianGuruCollection;

    public PresensiHarianGuruService(
        IOptions<PresensiHarianGuruDatabaseSettings> PresensiHarianGuruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PresensiHarianGuruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PresensiHarianGuruDatabaseSettings.Value.DatabaseName);

        _presensiHarianGuruCollection = mongoDatabase.GetCollection<PresensiHarianGuru>(
            PresensiHarianGuruDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _presensiHarianGuruCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _presensiHarianGuruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newBook) =>
        await _presensiHarianGuruCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedBook) =>
        await _presensiHarianGuruCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _presensiHarianGuruCollection.DeleteOneAsync(x => x.Id == id);
}