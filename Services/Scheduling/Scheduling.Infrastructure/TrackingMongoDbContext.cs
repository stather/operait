using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Infrastructure;
using Scheduling.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Infrastructure
{
    public class TrackingMongoDbContext : MongoDbContext
    {
        List<Entity> trackedEntities = new List<Entity>();
        public ReadOnlyCollection<Entity> TrackedEntities => trackedEntities.AsReadOnly();

        public TrackingMongoDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        public TrackingMongoDbContext(MongoClientSettings clientSettings, string databaseName, MongoDatabaseSettings databaseSettings = null) : base(clientSettings, databaseName, databaseSettings)
        {
        }

        public TrackingMongoDbContext(MongoUrl url, string databaseName, MongoDatabaseSettings databaseSettings = null) : base(url, databaseName, databaseSettings)
        {
        }

        public TrackingMongoDbContext(string connectionString, string databaseName, MongoDatabaseSettings databaseSettings = null) : base(connectionString, databaseName, databaseSettings)
        {
        }

        internal void TrackEntity(Entity entity)
        {
            trackedEntities.Add(entity);
        }
    }
}
