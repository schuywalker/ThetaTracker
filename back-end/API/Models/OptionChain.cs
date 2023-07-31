namespace API.Models;

public class OptionChain
{
    public required string ticker { get; set; }
    public long? startDate { get; set; }
    public long? endDate { get; set; }
    public List<OptionContract>? contracts { get; set; }
}