using BusinessLogic;
using DataAccess.Context;
using DataAccess.Repositories;
using IBusinessLogic;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MovieLogic, MovieLogic>();
            serviceCollection.AddScoped<MovieRepository, MovieRepository>();
        }

        public static void AddConnectionString(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, MovieContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
