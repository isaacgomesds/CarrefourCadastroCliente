using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Domain.Services;
using CSF.CadastroCliente.Domain.Services.Interfaces;
using CSF.CadastroCliente.Infrastructure;
using CSF.CadastroCliente.Infrastructure.Interfaces;
using CSF.CadastroCliente.Infrastructure.Repositories;
using CSF.CadastroCliente.Infrastructure.Repositories.Context;
using CSF.CadastroCliente.Infrastructure.Repositories.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSF.CadastroCliente.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IApplicationReadWriteDbConnection, ApplicationReadWriteDbConnection>();
            services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();

            return services;
        }
    }
}
