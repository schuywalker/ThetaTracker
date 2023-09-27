using MongoDB.Driver;
using API.Repositories;
using API.Services;



var builder = WebApplication.CreateBuilder(args);

// register mongo client
builder.Services.AddSingleton(sp =>
    new MongoClient(builder.Configuration["MongoDbSettings:ConnectionString"]));

// register IMongoDatabase
builder.Services.AddScoped(sp =>
{
    var mongoClient = sp.GetRequiredService<MongoClient>();
    return mongoClient.GetDatabase(builder.Configuration["MongoDbSettings:DatabaseName"]);
});

// register factory
builder.Services.AddTransient<IOptionContractsRepositoryFactory, OptionContractsRepositoryFactory>();

// reg services
builder.Services.AddScoped<IOptionContractsService, OptionContractsService>();

// register controllers
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
