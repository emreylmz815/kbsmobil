namespace KbsMobile.Helpers;

public static class ValidationHelper
{
    public static bool IsRequiredValid(string? value) => !string.IsNullOrWhiteSpace(value);
}
