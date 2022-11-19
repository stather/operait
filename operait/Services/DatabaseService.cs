using FeatureHubSDK;
using MongoDB.Bson;
using MongoDB.Driver;
using operait.Documents;
using Tag = operait.Documents.Tag;

namespace operait.Services
{
    public class DatabaseService
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<User> usersCollection;
        private IMongoCollection<Team> teamsCollection;
        private IMongoCollection<Tag> tagsCollection;
        private IMongoCollection<Integration> integrationsCollection;
        private IMongoCollection<Sequence> sequenceCollection;
        private IMongoCollection<Alert> alertCollection;

        public DatabaseService(IConfiguration configuration, IFeatureHubConfig config)
        {
            var connectionString = config.Repository.GetFeature("MongoConnectionString").StringValue;
            client = new MongoClient(connectionString);
            database = client.GetDatabase("OperaiteDB");
            usersCollection = database.GetCollection<User>("Users");
            teamsCollection = database.GetCollection<Team>("Teams");
            tagsCollection = database.GetCollection<Tag>("Tags");
            integrationsCollection = database.GetCollection<Integration>("Integrations");
            sequenceCollection = database.GetCollection<Sequence>("Sequences");
            alertCollection = database.GetCollection<Alert>("Alerts");
        }

        public async Task CheckDatabase()
        {
            var c = await integrationsCollection.CountDocumentsAsync<Integration>(i => i.Name == "Default API");
            if (c == 0)
            {
                var integ = new Integration
                {
                    Name = "Default API",
                    Enabled = true,
                    IntegrationType = IntegrationType.API,
                    Priority = AlertPriority.P3_Moderate,
                    SuppressNotifications = false,
                    ApiAttributes = new ApiAttributes
                    {
                        ApiKey = Guid.NewGuid().ToString(),
                        CreateAndUpdateAccess = true,
                        DeleteAccess = true,
                        ReadAccess = true,
                        RestrictConfigurationAccess = true,
                    }

                };
                await integrationsCollection.InsertOneAsync(integ);
            }
        }

        public async Task AddAlertAsync(Alert alert)
        {
            var filter = Builders<Sequence>.Filter.And(Builders<Sequence>.Filter.Eq("Name", "TinyId"));
            var update = Builders<Sequence>.Update.Inc("Value", 1);
            var s = await sequenceCollection.FindOneAndUpdateAsync<Sequence>(filter, update);
            await alertCollection.InsertOneAsync(alert);
        }


        public async Task<List<Integration>> GetApiIntegrations()
        {
            var l = await integrationsCollection.FindAsync<Integration>(x => x.IntegrationType == IntegrationType.API);
            return l.ToList();
        }

        #region User

        public async Task AddUserAsync(User user) { await usersCollection.InsertOneAsync(user); }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = (await usersCollection.FindAsync(user => true)).ToList();
            return users;
        }
        #endregion

        #region Team
        public async Task AddTeamAsync(Team team) { await teamsCollection.InsertOneAsync(team); }

        public async Task<List<Team>> GetAllTeamsAsync()
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
        #endregion

        #region tag
        public async Task<List<Tag>> GetAllTagsAsync()
        {
            var tags = (await tagsCollection.FindAsync(tag => true)).ToList();
            return tags;
        }
        public async Task AddTagAsync(Tag tag) { await tagsCollection.InsertOneAsync(tag); }

        #endregion

    }
}
