using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHarbor.Projects.WebApi.DependencyInjection;

namespace ProjectHarbor.Projects.WebApi.UnitTests.DependencyInjection;

public class ServiceCollectionTests
{
    [Fact]
    public void AddApplication_ShouldRegisterApplicationServices()
    {
        const string applicationNamespace = "ProjectHarbor.Projects.Application";

        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        services.AddWebApi(configuration);

        var hasApplicationServices = services.Any(service =>
            (service.ServiceType.Namespace ?? string.Empty).StartsWith(applicationNamespace));
        Assert.True(hasApplicationServices);
    }
}
