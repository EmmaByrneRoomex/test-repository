// Program.cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapOpenApi();

app.MapGet("/", () => new Response("Test App"))
    .WithName("Root")
    .Produces<Response>(200)
    .Produces(500);

app.MapGet("/hello", () => new Response("Hello, World!"))
    .WithName("Hello")
    .Produces<Response>(200)
    .Produces(500);

app.MapGet("/hello-redocly", () => new RedoclyResponse("Hello, Redocly!", "V2"))
    .WithName("HelloRedocly")
    .Produces<Response>(200)
    .Produces(500);

app.Run();


public record Response(string Message);
public record RedoclyResponse(string Message, string Version);
