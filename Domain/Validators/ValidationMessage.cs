namespace Domain.Validators;

public class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть NULL";
    public static string NotEmpty = "{PropertyName} не может быть пустым";
    public static string WrongLength = "{PropertyName} должен быть от {min} до {max}";
}