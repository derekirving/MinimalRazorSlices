# MinimalRazorSlices
return html from minimal api's

Create a directory named **Slices** and add a *_ViewImports.cshtml file*:

```c#
@inherits RazorSliceHttpResult

@using System.Globalization;
@using Microsoft.AspNetCore.Razor;
@using Microsoft.AspNetCore.Http.HttpResults;

@tagHelperPrefix __disable_tagHelpers__:
@removeTagHelper *, Microsoft.AspNetCore.Mvc.Razor
```

In the same directory, create a Razor Page called *Hello.cshtml*

```html
@inherits RazorSliceHttpResult<DateTime>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Hello from Razor Slices!</title>
</head>
<body>
    <p>
        Hello from Razor Slices! The time is @Model
    </p>
</body>
</html>
```

Wire it up in *Program.cs*

```c#
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => Results.Extensions.RazorSlice("/Slices/Hello.cshtml", DateTime.Now));
app.run
```
