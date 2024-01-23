using AutoMapper;
using ProjectHarbor.Projects.Application.Mappers;

namespace ProjectHarbor.Projects.Application.UnitTests.Mappers;

public class ProjectMapperTests
{
    private readonly MapperConfiguration _mapperConfiguration;
    private readonly Mapper _mapper;

    public ProjectMapperTests()
    {
        _mapperConfiguration = new MapperConfiguration(config => config.AddProfile<ProjectMapper>());
        _mapper = new Mapper(_mapperConfiguration);
    }

    [Fact]
    public void Map_ShouldHaveValidConfiguration()
    {
        _mapperConfiguration.AssertConfigurationIsValid();
    }
}
