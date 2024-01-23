using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHarbor.Projects.Application.DependencyInjection;

namespace ProjectHarbor.Projects.Application.UnitTests.DependencyInjection;

public class ServiceCollectionTests
{
    [Fact]
    public void AddApplication_ShouldRegisterMapper()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        services.AddApplication(configuration);

        AssertHasService<IMapper>(services);
    }

    [Fact]
    public void AddApplication_ShouldRegisterSender()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        services.AddApplication(configuration);

        AssertHasService<ISender>(services);
    }

    [Fact]
    public void AddApplication_ShouldRegisterPersistenceServices()
    {
        const string persistenceNamespace = "ProjectHarbor.Projects.Persistence";

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        services.AddApplication(configuration);

        var hasPersistenceServices = services.Any(service =>
            (service.ServiceType.Namespace ?? string.Empty).StartsWith(persistenceNamespace));
        Assert.True(hasPersistenceServices);
    }

    private static void AssertHasService<TService>(IServiceCollection services) where TService : notnull
    {
        var provider = services.BuildServiceProvider();
        _ = provider.GetRequiredService<TService>();
    }
}
