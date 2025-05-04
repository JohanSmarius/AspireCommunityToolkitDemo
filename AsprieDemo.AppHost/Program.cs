using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


var ollama = builder.AddOllama("ollama");
var phi35 = ollama.AddModel("phi3.5");

var sqlite = builder.AddSqlite("sqlite").WithSqliteWeb();

<<<<<<< HEAD
var weatherApi = builder.AddProject<Projects.AsprieDemo_ApiService>("weatherapi")
    .WithReference(sqlite)
    .WithReference(phi35)
    .WaitFor(sqlite);


=======
>>>>>>> 15f406af849a6ac512ea2c1ab36e02c6fa971956
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
    .WithReference(weatherApi);


builder.Build().Run();
