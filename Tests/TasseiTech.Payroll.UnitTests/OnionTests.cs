using Microsoft.Extensions.Logging;
using Moq;
using TasseiTech.Sample.Core.Domain.Abstractions;
using TasseiTech.Sample.Core.Services.Services;

namespace TasseiTech.Sample.Tests.UnitTests;
public class OnionServiceTests
{
    private readonly Mock<IEmployeeRepository> _mockRepository;
    private readonly Mock<ILogger<EmployeeService>> _logger;


    public OnionServiceTests()
    {
        _mockRepository = new Mock<IEmployeeRepository>(MockBehavior.Strict);
        _logger = new Mock<ILogger<EmployeeService>>(MockBehavior.Strict);
    }

    private EmployeeService CreateService()
    {
        return new EmployeeService(this._mockRepository.Object, this._logger.Object);
    }
}