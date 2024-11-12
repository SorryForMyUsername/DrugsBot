namespace Domain.Validators;

public class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть NULL.";
    public static string NotEmpty = "{PropertyName} не может быть пустым.";
    public static string WrongLength = "{PropertyName} должен быть от {MinLength} до {MaxLength}.";
    public static string WrongFormat = "{PropertyName} в неправильном формате.";
    public static string LessThanNeed = "{PropertyName} должен быть больше {ComparisonValue}.";
    public static string GreaterThanNeed = "{PropertyName} должен быть меньше {ComparisonValue}.";
    public static string NotExistValue = "{PropertyName} не существует со значением {PropertyValue}.";
    public static string WrongScale = "У {PropertyName} должно быть {ExpectedScale} знака(-ов) после запятой.";
    public static string WrongExactLength = "{PropertyName} должен иметь длину {MinLength}.";
    public static string NotUnique = "{PropertyName} должен быть уникален.";
}