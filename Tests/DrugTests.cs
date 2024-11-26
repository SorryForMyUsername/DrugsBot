using Domain.Entities;
using FluentValidation;

namespace Tests;

public class DrugTests
{
    [Fact]
    public void Test()
    {
        string expected = "0 exceptions.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestName1()
    {
        string expected = "Поле Name должно содержать от 2 до 150 символов.";

        string actual = CatchDrugValidateException("D", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName2()
    {
        string expected = "Поле Name является обязательным.";

        string actual = CatchDrugValidateException(null, "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName3()
    {
        string expected = "Поле Name является обязательным. Поле Name должно содержать от 2 до 150 символов. Поле Name должно содержать только буквы, цифры и пробелы.";

        string actual = CatchDrugValidateException("", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName4()
    {
        string expected = "0 exceptions.";

        string actual = CatchDrugValidateException("Drug34", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName5()
    {
        string expected = "Поле Name должно содержать только буквы, цифры и пробелы.";

        string actual = CatchDrugValidateException("(Drug)", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName6()
    {
        string expected = "Поле Name должно содержать от 2 до 150 символов. Поле Name должно содержать только буквы, цифры и пробелы.";
        Country russia = new Country("Russian Federation", "RU"); 
        
        string actual = CatchDrugValidateException("=", "Manufacturer", "RU", russia);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer1()
    {
        string expected = "Поле Manufacturer является обязательным.";

        string actual = CatchDrugValidateException("Drug", null, "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer2()
    {
        string expected = "Поле Manufacturer является обязательным. Поле Manufacturer должно содержать от 2 до 100 символов. Поле Manufacturer должно содержать только буквы, пробелы и дефисы.";

        string actual = CatchDrugValidateException("Drug", "", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer3()
    {
        string expected = "Поле Manufacturer должно содержать от 2 до 100 символов.";

        string actual = CatchDrugValidateException("Drug", "m", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer4()
    {
        string expected = "Поле Manufacturer должно содержать от 2 до 100 символов. Поле Manufacturer должно содержать только буквы, пробелы и дефисы.";

        string actual = CatchDrugValidateException("Drug", "1", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer5()
    {
        string expected = "0 exceptions.";

        string actual = CatchDrugValidateException("Drug", "mA --- Er", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer6()
    {
        string expected = "Поле Manufacturer должно содержать только буквы, пробелы и дефисы.";

        string actual = CatchDrugValidateException("Drug", "M a-n U-f a-C t-u r-3 r", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId1()
    {
        string expected = "Поле Country Code Id является обязательным. Поле Country Code Id должно соответствовать существующему ISO-коду страны.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", null, new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId2()
    {
        string expected = "Поле Country Code Id должно соответствовать существующему ISO-коду страны.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "RY", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId3()
    {
        string expected = "0 exceptions.";
        Country Canada = new Country("United States of America", "US");
        Country China = new Country("Germany", "DE");
        Country India = new Country("France", "FR");

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "DE", new Country("Russian Federation", "DE"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId4()
    {
        string expected = "Поле Country Code Id должно содержать ровно 2 символов. Поле Country Code Id должно содержать только заглавные латинские буквы. Поле Country Code Id должно соответствовать существующему ISO-коду страны.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "r", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId5()
    {
        string expected = "Поле Country Code Id должно содержать ровно 2 символов. Поле Country Code Id должно содержать только заглавные латинские буквы. Поле Country Code Id должно соответствовать существующему ISO-коду страны.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "RURU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    /// <summary>
    /// Проверяет на наличие ValidationException при создании экземпляра класса Drug.
    /// </summary>
    /// <returns>Возвращает "0 exceptions." при отсутствии исключений, либо возвращает описание исключения в виде строки при возникновении ValidationException</returns>
    private string CatchDrugValidateException(string name, string manufacturer, string countryCodeId, Country country)
    {
        try
        {
            Drug d = new Drug(name, manufacturer, countryCodeId, country, s => ISO3166.Country.List.Any(c => c.TwoLetterCode == s));
            return "0 exceptions.";
        }
        catch(ValidationException ex)
        {
            return ex.Message;
        }
    }
}