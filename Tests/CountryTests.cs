using Domain.Entities;
using FluentValidation;

namespace Tests;

public class CountryTests
{
    [Fact]
    public void Test()
    {
        string expected = "0 exceptions.";

        string actual = CatchCountryValidateException("Moldova", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName1()
    {
        string expected = "Name не может быть NULL. Name не может быть пустым.";

        string actual = CatchCountryValidateException(null, "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName2()
    {
        string expected = "Name не может быть пустым. Name должен быть от 2 до 100.";

        string actual = CatchCountryValidateException("", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName3()
    {
        string expected = "Name должен быть от 2 до 100.";

        string actual = CatchCountryValidateException("M", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName4()
    {
        string expected = "Name в неправильном формате.";

        string actual = CatchCountryValidateException("Moldova 2", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName5()
    {
        string expected = "Name должен быть от 2 до 100. Name в неправильном формате.";

        string actual = CatchCountryValidateException("0", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName6()
    {
        string expected = "Name должен быть от 2 до 100.";

        string actual = CatchCountryValidateException("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode1()
    {
        string expected = "0 exceptions.";

        string actual = CatchCountryValidateException("Moldova", null);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode2()
    {
        string expected = "Code должен иметь длину 2.";

        string actual = CatchCountryValidateException("Moldova", "M");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode3()
    {
        string expected = "Code в неправильном формате.";

        string actual = CatchCountryValidateException("Moldova", "mD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode4()
    {
        string expected = "Code должен иметь длину 2. Code в неправильном формате.";

        string actual = CatchCountryValidateException("Moldova", "$M4D");
        
        Assert.Equal(expected, actual);
    }
    
    /// <summary>
    /// Проверяет на наличие ValidationException при создании экземпляра класса Country.
    /// </summary>
    /// <returns>Возвращает "0 exceptions." при отсутствии исключений, либо возвращает описание исключения в виде строки при возникновении ValidationException</returns>
    private string CatchCountryValidateException(string name, string code)
    {
        try
        {
            Country c = new Country(name, code);
            return "0 exceptions.";
        }
        catch(ValidationException ex)
        {
            return ex.Message;
        }
    }
}