using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName_Or_LastName()
    {
        //Arrange
        var service = new UserService();
        //Act
        var result = service.AddUser(null, null, "aa@wp.pl", new DateTime(2000, 10, 13), 1);
        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
    {
        //Arrange
        var service = new UserService();
        //Act
        var result = service.AddUser("Jan", "Kowalski", "aawppl", new DateTime(2000, 10, 13), 1);
        //Assert
        Assert.Equal(false, result);
    }
    [Fact] 
    public void AddUser_Should_Return_False_When_Normal_Client_With_No_Credit_Limit()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("Jan","Kowalski", "kowalski@wp.pl", new DateTime(2000, 10, 13), 1);
        //Assert
        Assert.Equal(false, result);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Than_21_Years_Old()
    {
        //Arrange
        var service = new UserService();
        //Act
        var result = service.AddUser("Jan","Kowalski", "aa@wp.pl", new DateTime(2020, 10, 13), 1);
        //Assert
        Assert.Equal(false, result);
    }
    [Fact] 
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("Smith","Kowalski", "smith@gmail.pl", new DateTime(2000, 10, 13), 3);
        //Assert
        Assert.Equal(true, result);
    }
    [Fact] 
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("Jan","Kwiatkowski", "kwiatkowski@wp.pl", new DateTime(2000, 10, 13), 5);
        //Assert
        Assert.Equal(true, result);
    }
    [Fact] 
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("Jan","Kowalski", "kowalski@wp.pl", new DateTime(2000, 10, 13), 2);
        //Assert
        Assert.Equal(true, result);
    }
    [Fact] 
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(()=> service.AddUser("Jan","Arka", "kowalski@wp.pl", new DateTime(2000, 10, 13), 33));

    }
    [Fact] 
    public void AddUser_Should_Throw_Exception_When_User_Credit_Limit_Does_Not_Exist()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(()=> service.AddUser("Jan","Andrzejewicz", "kowalski@wp.pl", new DateTime(2000, 10, 13), 6));
    }
    
}