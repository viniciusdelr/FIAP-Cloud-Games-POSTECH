using FCG.Domain.Entities;
using Xunit;
using FluentAssertions;

public class UsersTests
{
    [Fact]
    public void RegisterUser_CorrectProps()
    {
        var user = new Users
        {
            Id = 1,
            Username = "usuario1",
            FirstName = "João",
            LastName = "Silva",
            Email = "joao@email.com",
            Admin = true,
            Password = "123456"
        };

        user.Id.Should().Be(1);
        user.Username.Should().Be("usuario1");
        user.FirstName.Should().Be("João");
        user.LastName.Should().Be("Silva");
        user.Email.Should().Be("joao@email.com");
        user.Admin.Should().BeTrue();
        user.Password.Should().Be("123456");
    }
}
