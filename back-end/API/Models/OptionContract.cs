namespace API.Models;

public class OptionContract
{
    [MongoDB.Bson.Serialization.Attributes.BsonId]
    public MongoDB.Bson.ObjectId Id { get; set; }
    public required string dayCreated { get; set; }
    public long createdTS { get; set; }
    public required string contractSymbol { get; set; }
    public required string ticker { get; set; }
    public long expirationDateTS { get; set; }
    public required string cp { get; set; }
    public double strike { get; set; }
    public string? currency { get; set; }
    public double lastPrice { get; set; }
    public double change { get; set; }
    public double percentChange { get; set; }
    public int volume { get; set; }
    public int openInterest { get; set; }
    public double bid { get; set; }
    public double ask { get; set; }
    public string? contractSize { get; set; }
    public long lastTradeDate { get; set; }
    public string? impliedVolatility { get; set; }
    public bool inTheMoney { get; set; }

    public override string ToString()
    {
        return $"ContractSymbol: {contractSymbol}, \n" +
               $"Ticker: {ticker}, \n" +
               $"ExpirationDateTS: {expirationDateTS}, \n" +
               $"Strike: {strike}, \n" +
               $"Currency: {currency}, \n" +
               $"LastPrice: {lastPrice}, \n" +
               $"Change: {change}, \n" +
               $"PercentChange: {percentChange}, \n" +
               $"Volume: {volume}, \n" +
               $"OpenInterest: {openInterest}, \n" +
               $"Bid: {bid}, \n" +
               $"Ask: {ask}, \n" +
               $"ContractSize: {contractSize}, \n" +
               $"LastTradeDate: {lastTradeDate}, \n" +
               $"ImpliedVolatility: {impliedVolatility}, \n" +
               $"InTheMoney: {inTheMoney}\n";
    }


}

