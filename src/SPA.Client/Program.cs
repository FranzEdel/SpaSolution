
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //Habilita los controladores
var app = builder.Build();

app.UseSpa(spa =>
{
    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
});

//app.MapGet("/", () => "Hello Worlddddddd!");
app.MapControllers(); //Mapear controladores
app.Run();
