var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => new {Name = "Vantercarlos", Age = 41});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Vantercarlos");
    return new {Name = "Vantercarlos", Age = 41};
    });

app.Run();

