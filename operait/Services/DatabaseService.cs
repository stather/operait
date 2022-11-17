using FeatureHubSDK;
using MongoDB.Driver;
using operait.Documents;

namespace operait.Services
{
    public class DatabaseService
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<User> usersCollection;
        private IMongoCollection<Team> teamsCollection;

        public DatabaseService(IConfiguration configuration, IFeatureHubConfig config)
        {
            var connectionString = config.Repository.GetFeature("MongoConnectionString").StringValue;
            client = new MongoClient(connectionString);
            database = client.GetDatabase("OperaiteDB");
            usersCollection = database.GetCollection<User>("Users");
            teamsCollection = database.GetCollection<Team>("Teams");
        }

        public async Task AddUserAsync(User user) { await usersCollection.InsertOneAsync(user); }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = (await usersCollection.FindAsync(user => true)).ToList();
            return users;
        }

        public async Task AddTeamAsync(Team team) { await teamsCollection.InsertOneAsync(team); }

        public async Task <List<Team>> GetAllTeamsAsync() 
        { 
            var teams = (await teamsCollection.FindAsync(team => true)).ToList();
            return teams;
        }

        public async Task<Team> GetTeamAsync(string id)
        {
            var team = (await teamsCollection.FindAsync(x => x.Id == id)).FirstOrDefault();
            return team;
        }

        public async Task UpdateTeamAsync(Team team)
        {
            await teamsCollection.ReplaceOneAsync(a => a.Id == team.Id, team);
        }

    }
}
