using System;

namespace API.Utils;

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
    public static OptionType StringToOptionType(string cp)
    {
        // might be doing string == string, fix to be comparing values not addresses
        return cp.ToUpper() switch
        {
            "C" => OptionType.CALL,
            "P" => OptionType.PUT,
            _ => throw new NotImplementedException(),
        };
    }
}


