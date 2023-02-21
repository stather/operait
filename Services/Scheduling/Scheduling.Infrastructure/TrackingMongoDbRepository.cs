using MongoDB.Driver;
using MongoDB.Infrastructure;
using MongoDB.Repository;
using Scheduling.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Infrastructure
{
    public class TrackingMongoDbRepository<T> : MongoDbRepository<T> where T : Entity
    {
        public TrackingMongoDbRepository(IMongoDbContext context) : base(context)
        {
        }

        public override object InsertOne(T entity, InsertOneOptions options = null)
        {
            var TrackingContext = Context as TrackingMongoDbContext;
            TrackingContext.TrackEntity(entity);
            return base.InsertOne(entity, options);
        }
    }
}
