using Moq;
using Tekus.Application.Common.Exceptions;
using Tekus.Application.Features.Auth.Commands.Login;
using Tekus.Application.Interfaces.Services;


namespace Tekus.Tests;

public class LoginCommandHandlerTests
{
    private readonly Mock<IJwtService> _jwtServiceMock;
    private readonly LoginCommandHandler _handler;

    public LoginCommandHandlerTests()
    {
        _jwtServiceMock = new Mock<IJwtService>();
        _handler = new LoginCommandHandler(_jwtServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCredentials_ReturnsToken()
    {
        // Arrange
        var command = new LoginCommand("admin", "Tekus2025*");
        _jwtServiceMock
            .Setup(x => x.GenerateToken("admin"))
            .Returns("fake-jwt-token");

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("fake-jwt-token", result.Token);
        Assert.True(result.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public async Task Handle_InvalidUsername_ThrowsInvalidCredentialsException()
    {
        // Arrange
        var command = new LoginCommand("wrong", "Tekus2025*");

        // Act & Assert
        await Assert.ThrowsAsync<InvalidCredentialsException>(
            () => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_InvalidPassword_ThrowsInvalidCredentialsException()
    {
        // Arrange
        var command = new LoginCommand("admin", "wrongpassword");

        // Act & Assert
        await Assert.ThrowsAsync<InvalidCredentialsException>(
            () => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ValidCredentials_DoesNotCallJwtService_WhenCredentialsWrong()
    {
        // Arrange
        var command = new LoginCommand("admin", "wrong");

        // Act
        try { await _handler.Handle(command, CancellationToken.None); } catch { }

        // Assert
        _jwtServiceMock.Verify(x => x.GenerateToken(It.IsAny<string>()), Times.Never);
    }
}