using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Linq;
using API.Services;
using System.Collections.Generic;
using System.Globalization;
using System;
using MongoDB.Driver;
using MongoDB.Bson;
using API.Utils;
using API.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractRetrievalController : ControllerBase
{
    
    private readonly IOptionContractsService _service;
    private readonly ILogger<ContractRetrievalController> _logger;

    public ContractRetrievalController( IOptionContractsService service,ILogger<ContractRetrievalController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("GetContracts")]
    public IActionResult GetContracts(
       string ticker = "AI",
       double strike = 30, // add nullability
       string optionType = "",
       DateTime? startDate = null,
       DateTime? endDate = null,
       DateTime? expDateStart = null,
       DateTime? expDateEnd = null)
    {

        var contracts = _service.GetOptionContracts(
            ticker, 
            strike, 
            startDate ?? DateTime.ParseExact("2023-09-19", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
            endDate ?? DateTime.ParseExact("2023-09-19", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
            OptionTypeHelper.StringToOptionType(optionType),
            expDateStart, 
            expDateEnd);
        return Ok(contracts);
    }

    //    // PRINTING A BUNCH OF STUFF
    //    Console.WriteLine(documents.Count);
    //    foreach (var doc in documents)
    //    {
    //        Console.WriteLine($"bid: {doc.bid} ask: {doc.ask} expiration: {DateManip.TimestampToDateTime(doc.expirationDateTS)}");
    //    }
    //    List<OptionContract> putsExample = service.GetOptionContracts(30, date, date, Utils.OptionType.PUT, null, null);
    //    Console.WriteLine(putsExample.Count);
    //    foreach (var put in putsExample)
    //    {
    //        Console.WriteLine($"bid: {put.bid} ask: {put.ask} expiration: {DateManip.TimestampToDateTime(put.expirationDateTS)}");
    //    }
    //    Console.WriteLine($"\n{putsExample[0]}");

  
}
