using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => new {Name = "Vantercarlos", Age = 41});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Vantercarlos");
    return new {Name = "Vantercarlos", Age = 41};
});

app.MapPost("/saveProduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

app.MapGet("/getProduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getProduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}

