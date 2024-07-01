using Moq;

namespace TasseiTech.OnionArchitecture.Tests.UnitTests;
public class OnionServiceTests
{
    private readonly MockRepository _mockRepository;
    //private readonly Mock<IRepository> _mockOnionRepository;


    public OnionServiceTests()
    {
        this._mockRepository = new MockRepository(MockBehavior.Strict);
        //this._mockOnionRepository = this._mockRepository.Create<IRepository>();
    }

    //private OnionService CreateService()
    //{
    //    return new OnionService(this._mockOnionRepository.Object);
    //}

    //[Fact]
    //public async Task EatOnionAsync_FoundInRepository_ShouldBeSuccesful()
    //{
    //    // Arrange.
    //    var onionService = CreateService();
    //    var request = new EatOnionRequest { Id = 5 };
    //    _mockOnionRepository.Setup(x => x.GetByIdAsync(It.Is<int>(i => i == request.Id))).ReturnsAsync(new BaseEntity { Id = request.Id });

    //    // Act.
    //    var sut = await onionService.EatOnionAsync(request);

    //    // Assert.
    //    sut.Id.Should().Be(request.Id);
    //}
}