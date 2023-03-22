var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => Results.Extensions.RazorSlice("/Slices/Hello.cshtml", DateTime.Now));

app.Run();
