using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


var ollama = builder.AddOllama("ollama");
var phi35 = ollama.AddModel("phi3.5");

var sqlite = builder.AddSqlite("sqlite").WithSqliteWeb();

var weatherApi = builder.AddProject<Projects.AsprieDemo_ApiService>("weatherapi")
    .WithReference(sqlite)
    .WithReference(phi35)
    .WaitFor(sqlite);

var api = builder.AddProject<Projects.ShopAPI>("shopapi")
    .WithReference(sqlite)
    .WithReference(phi35)
    .WaitFor(sqlite);


builder.AddProject<Projects.AsprieDemo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(api)
    .WaitFor(api)
    .WithReference(weatherApi)
    .WaitFor(weatherApi);


builder.Build().Run();
