using Scrutor;
using Microsoft.Extensions.DependencyInjection;
using exemplo.crud.compartilhado.interfaces;

namespace exemplo.crud.core;

public static class Configuracao
{
    public static IServiceCollection AddServicos(this IServiceCollection services) =>
        services.Scan(x => x.FromCallingAssembly().AddClasses(filter =>
                filter.AssignableToAny(typeof(IServico<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
}