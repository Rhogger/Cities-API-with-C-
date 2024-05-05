using Cities_API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cities_API_Tests;

public class CEPControllerTest
{
    [Fact]
    public void Test1()
    {
        var dataLoadMock = new Mock<IDataLoad>();
        var loggerMock = new Mock<ILogger<CEPController>>();

        List<City> citiesMock = [new City { state_code = "GO", country_code = "BR", name = "test" }];

        dataLoadMock.Setup(method => method.Cities()).Returns(citiesMock);
        var controllerMock = new CEPController(loggerMock.Object, dataLoadMock.Object);

        var result = controllerMock.Cities("GO", "BR");

        Assert.Single(result);
        Assert.Contains("test", result);
    }
}