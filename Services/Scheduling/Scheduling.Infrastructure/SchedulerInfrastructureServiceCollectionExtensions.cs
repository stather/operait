using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Infrastructure;
using MongoDB.Infrastructure.Extensions;
using MongoDB.UnitOfWork.Abstractions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Infrastructure
{
    public static class SchedulerInfrastructureServiceCollectionExtensions
    {
        public static void AddSchedulerInfrastructure(this IServiceCollection services)
        {
            services.AddMongoDbContext<IMongoDbContext, SchedulingContext>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetValue<string>("MongoSettings:ConnectionString");
                var databaseName = configuration.GetValue<string>("MongoSettings:DatabaseName");
                var mediator = provider.GetRequiredService<IMediator>();
                return new SchedulingContext(connectionString, databaseName, mediator);
            });

            services.AddMongoDbUnitOfWork();
            services.AddMongoDbUnitOfWork<SchedulingContext>();
        }
    }
}
