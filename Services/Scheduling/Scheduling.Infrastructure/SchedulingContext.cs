using MediatR;
using MongoDB.Driver;
using MongoDB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Infrastructure
{
    public class SchedulingContext : TrackingMongoDbContext
    {
        readonly IMediator mediator;
        public SchedulingContext(string connectionString, string databaseName, IMediator mediator, MongoDatabaseSettings databaseSettings = null) 
            : base(connectionString, databaseName, databaseSettings)
        {
            this.mediator = mediator;
            AcceptAllChangesOnSave = true;
            //ApplyConfigurationsFromAssembly(typeof(BloggingContext).Assembly);
        }

        public new async Task<ISaveChangesResult> SaveChanges()
        {
            await mediator.DispatchDomainEventsAsync(this);
            return base.SaveChanges();
        }

    }
}
