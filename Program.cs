using SignalR;
using System.Web;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddScoped<IMyHubCaller, MyHubCaller>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCorsPolicy", b =>
    {
        b
            .WithOrigins("http://localhost:4200/")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("MyCorsPolicy");

app.MapHub<MyHub>("/chat");

app.MapGet("/", () => "Hello World!");
app.MapPost("/send", ([FromBody] string message, [FromServices] IMyHubCaller myHubCaller) =>
{
    myHubCaller.SendMessage(message);
    return "Message sent!";
});
app.Run();