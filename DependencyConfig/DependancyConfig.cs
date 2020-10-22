using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.BuildingBlocks.Infrastructure;
using SD.BuildingBlocks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Infrastructure.Repositories;
using WebApi.Interfaces;
using WebApi.Services.Services;

namespace WebApi.DependencyConfig
{
    public class DependancyConfig
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public DependancyConfig(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            _services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));
            _services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // register services
            _services.AddScoped<IServeyMasterService, ServeyMasterService>();
          
            // Register Application repositories.
            _services.AddScoped<IQuestionRepository, QuestionRepositories>();
            _services.AddScoped<IServeyMasterRepository, ServeyMasterRepositories>();
            _services.AddScoped<IChoicesRepository, ChoicesRepositories>();
        }
    }
}
