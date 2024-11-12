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
        string expected = "Name должен быть от 2 до 150.";

        string actual = CatchDrugValidateException("D", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName2()
    {
        string expected = "Name не может быть NULL. Name не может быть пустым.";

        string actual = CatchDrugValidateException(null, "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName3()
    {
        string expected = "Name не может быть пустым. Name должен быть от 2 до 150.";

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
        string expected = "Name в неправильном формате.";

        string actual = CatchDrugValidateException("(Drug)", "Manufacturer", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestName6()
    {
        string expected = "Name должен быть от 2 до 150. Name в неправильном формате.";
        Country russia = new Country("Russian Federation", "RU"); 
        
        string actual = CatchDrugValidateException("=", "Manufacturer", "RU", russia);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer1()
    {
        string expected = "Manufacturer не может быть NULL. Manufacturer не может быть пустым.";

        string actual = CatchDrugValidateException("Drug", null, "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer2()
    {
        string expected = "Manufacturer не может быть пустым. Manufacturer должен быть от 2 до 100.";

        string actual = CatchDrugValidateException("Drug", "", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer3()
    {
        string expected = "Manufacturer должен быть от 2 до 100.";

        string actual = CatchDrugValidateException("Drug", "m", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestManufacturer4()
    {
        string expected = "Manufacturer должен быть от 2 до 100. Manufacturer в неправильном формате.";

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
        string expected = "Manufacturer в неправильном формате.";

        string actual = CatchDrugValidateException("Drug", "M a-n U-f a-C t-u r-3 r", "RU", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId1()
    {
        string expected = "0 exceptions.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", null, new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId2()
    {
        string expected = "Country Code Id не существует со значением RY.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "RY", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId3()
    {
        string expected = "0 exceptions.";
        Country Canada = new Country("Canada", "CA");
        Country China = new Country("China", "CL");
        Country India = new Country("India", "IN");

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "CL", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId4()
    {
        string expected = "Country Code Id в неправильном формате. Country Code Id не существует со значением r.";

        string actual = CatchDrugValidateException("Drug", "Manufacturer", "r", new Country("Russian Federation", "RU"));
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void TestCountryCodeId5()
    {
        string expected = "Country Code Id в неправильном формате. Country Code Id не существует со значением RURU.";

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
            Drug d = new Drug(name, manufacturer, countryCodeId, country);
            return "0 exceptions.";
        }
        catch(ValidationException ex)
        {
            return ex.Message;
        }
    }
}