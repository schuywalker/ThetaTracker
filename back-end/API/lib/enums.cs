namespace API.lib;

public enum OptionType
{
    CALL,
    PUT,
}
public static class OptionTypeHelper
{
    public static string OptionTypeToString(OptionType cp)
    {
        return cp switch
        {
            OptionType.CALL => "C",
            OptionType.PUT => "P",
            _ => throw new NotImplementedException(),
        };
    }
}


