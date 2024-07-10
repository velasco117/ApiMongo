using ApiMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongo.Services
{
    public class LoginServicecs
    {
        private readonly IMongoCollection<Login> _loginCollection;
        public LoginServicecs(IOptions<DataBaseSettings> dataBaseSettings)
        {
            var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
            _loginCollection = mongoDatabase.GetCollection<Login>(dataBaseSettings.Value.LoginCollection);

        }

        public async Task<List<Login>> GetAsync() =>
           await _loginCollection.Find(_ => true).ToListAsync();
        
        public async Task<Login?> GetAsync(string id) =>
            await _loginCollection.Find( x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserAsync(Login newUser) =>
            await _loginCollection.InsertOneAsync(newUser);

        public async Task GetDAsync(string id) =>
          await _loginCollection.Find( x => x.Id == id).ToListAsync(); 
        

          
    }
}
