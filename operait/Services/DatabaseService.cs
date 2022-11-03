using MongoDB.Driver;
using operait.Documents;

namespace operait.Services
{
    public class DatabaseService
    {
        private MongoClient client;
        private IMongoDatabase database;

        public DatabaseService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoConnectionString"];
            client = new MongoClient(connectionString);
            database = client.GetDatabase("OperaiteDB");
        }

        public async Task AddUserAsync(User user)
        {
            var users = database.GetCollection<User>("Users");
            await users.InsertOneAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = (await database.GetCollection<User>("Users").FindAsync(user => true)).ToList();
            return users;
        }

    }
}
