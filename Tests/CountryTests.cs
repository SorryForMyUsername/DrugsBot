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
        string expected = "Поле Name является обязательным.";

        string actual = CatchCountryValidateException(null, "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName2()
    {
        string expected = "Поле Name является обязательным. Поле Name должно содержать от 2 до 100 символов. Поле Name должно содержать только буквы и пробелы.";

        string actual = CatchCountryValidateException("", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName3()
    {
        string expected = "Поле Name должно содержать от 2 до 100 символов.";

        string actual = CatchCountryValidateException("M", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName4()
    {
        string expected = "Поле Name должно содержать только буквы и пробелы.";

        string actual = CatchCountryValidateException("Moldova 2", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName5()
    {
        string expected = "Поле Name должно содержать от 2 до 100 символов. Поле Name должно содержать только буквы и пробелы.";

        string actual = CatchCountryValidateException("0", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName6()
    {
        string expected = "Поле Name должно содержать от 2 до 100 символов.";

        string actual = CatchCountryValidateException("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "MD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode1()
    {
        string expected = "Поле Code является обязательным. Поле Code должно соответствовать существующему ISO-коду страны.";

        string actual = CatchCountryValidateException("Moldova", null);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode2()
    {
        string expected = "Поле Code должно содержать ровно 2 символов. Поле Code должно содержать только заглавные латинские буквы. Поле Code должно соответствовать существующему ISO-коду страны.";

        string actual = CatchCountryValidateException("Moldova", "M");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode3()
    {
        string expected = "Поле Code должно содержать только заглавные латинские буквы. Поле Code должно соответствовать существующему ISO-коду страны.";

        string actual = CatchCountryValidateException("Moldova", "mD");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCode4()
    {
        string expected = "Поле Code должно содержать ровно 2 символов. Поле Code должно содержать только заглавные латинские буквы. Поле Code должно соответствовать существующему ISO-коду страны.";

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