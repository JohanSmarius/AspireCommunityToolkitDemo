using ShopAPI.Repository;
using ShopAPI.Database;
using System.Data.Common;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddSqliteDbContext<OrderContext>("sqlite");


// string? papercutConnectionString = builder.Configuration.GetConnectionString("papercut");
// DbConnectionStringBuilder connectionBuilder = new()
// {
//     ConnectionString = papercutConnectionString
// };
//
// Uri endpoint = new(connectionBuilder["Endpoint"].ToString()!, UriKind.Absolute);
// builder.Services.AddScoped(_ => new SmtpClient(endpoint.Host, endpoint.Port));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();