using ApiMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongo.Services
{
    public class ServiceProduct
    {
        private readonly IMongoCollection<Student> _productosCollection;

        public ServiceProduct(IOptions<DataBaseSettings> dataBaseSettings)
        {
            var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
            Console.WriteLine(mongoClient);
            var mongoDatabase = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
            _productosCollection = mongoDatabase.GetCollection<Student>(dataBaseSettings.Value.CollectionName);
        }

        public async Task<List<Student>> GetAsync() =>
            await _productosCollection.Find(_ => true).ToListAsync();

        public async Task<Student> GetAsync(string id) =>
            await _productosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student newStudent) =>
            await _productosCollection.InsertOneAsync(newStudent);

    }
}
