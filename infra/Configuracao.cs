using Scrutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using exemplo.crud.compartilhado.interfaces;
using exemplo.crud.infra.data;

namespace exemplo.crud.infra;

public static class Configuracao
{
    public static void AddContexto(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<DataContexto>(options =>
          options
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseSqlServer(connectionString));

    public static void AddRepositorios(this IServiceCollection services) =>
      services.Scan(x => x.FromCallingAssembly().AddClasses(filter =>
                filter.AssignableToAny(typeof(IRepositorio<>)))
                  .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                  .AsImplementedInterfaces()
                  .WithScopedLifetime());

}
