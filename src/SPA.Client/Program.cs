//using Microsoft.AspNetCore.builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseSpa(spa => {
    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
});

//app.MapGet("/", () => "Hello Worlddddddd!");

app.Run();
