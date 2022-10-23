using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;

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

app.MapGet("/getProductByHeader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();

public static class ProductRepository {
    public static List<Product> Products {get; set;}

    public static void Add(Product product) {
        if(Products == null)
            Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code) {
        return Products.First(p => p.Code == code);
    }
}

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}

