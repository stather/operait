using FeatureHubSDK;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using operait.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            c = await sequenceCollection.CountDocumentsAsync(x => x.Name == "TinyId");
            if (c == 0)
            {
                await sequenceCollection.InsertOneAsync(new Sequence { Name = "TinyId", Value = 0 });
            }
        }

        #region alerts
        public async Task AddAlertAsync(Alert alert)
        {
            var update = Builders<Sequence>.Update.Inc(f => f.Value, 1);
            var s = await sequenceCollection.FindOneAndUpdateAsync(f => f.Name == "TinyId", update);
            alert.TinyId = s.Value;
            await alertCollection.InsertOneAsync(alert);
        }

        internal async Task<List<Alert>> GetAllAlertsAsync()
        {
            var l = await alertCollection.FindAsync(x => true);
            return l.ToList();
        }

        public async Task<Alert> GetAlertAsync(string id)
        {
            var team = (await alertCollection.FindAsync(x => x.Id== id)).FirstOrDefault();
            return team;
        }

        #endregion



        #region integrations
        public async Task<List<Integration>> GetApiIntegrations()
        {
            var l = await integrationsCollection.FindAsync<Integration>(x => x.IntegrationType == IntegrationType.API);
            return l.ToList();
        }
        #endregion

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
