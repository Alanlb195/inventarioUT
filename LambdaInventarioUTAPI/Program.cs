using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//-------- Add services to the container ----------//

// Controladores y DBContext
var myconnection = builder.Configuration.GetConnectionString("AmazonRDSinventarioutdbConnection");
builder.Services.AddControllers().Services.AddDbContext<InventarioUTDBContext>(options =>
{
    options.UseMySql(myconnection, ServerVersion.AutoDetect(myconnection));
});


// CORS - https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // To allow IONIC Connections
                          policy.WithOrigins("http://localhost:8100")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddSwaggerGen();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

//-------- End of the container ----------//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Swagger doc configuration Prod
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        var myString = "letsReadTheApiDoc"; // Swagger Doc Production Environment
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(setup.RoutePrefix) ? "." : "..";
        setup.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "version 1.0");
        setup.OAuthAppName("Lambda API");
        setup.OAuthScopeSeparator(" ");
        setup.OAuthUsePkce();
        setup.RoutePrefix = myString;
    });
}


app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");
app.Run();
