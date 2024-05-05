namespace HighCode.Domain.Constants;

public class FilterTypeConstants
{
    public const string ByLanguage = "language";
    public const string ByComplexity = "complexity";
    public const string ByCategory = "category";

    public static IEnumerable<string> GetAll()
    {
        return [ByLanguage, ByCategory, ByComplexity];
    }
}