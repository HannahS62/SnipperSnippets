using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SnipperSnippetApi.Data;
using SnipperSnippetApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


// Seed data setup
var snippets = SeedData.GetSeedSnippets();


//GET all snippets
app.MapGet("/snippets", () =>
{
    
    return Results.Ok(snippets) ;
});

//Test in postman: GET http://localhost:0000/snippets

//GET with id
app.MapGet("/snippets/{id}", (int id) =>
{
    var snippet = snippets.FirstOrDefault(s => s.Id == id);
    return snippet != null ? Results.Ok(snippet) : Results.NotFound($"Snippet with ID {id} not found.");
});

//Test in postman: GET http://localhost:0000/snippets/id

//POST
app.MapPost("/snippets", (Snippet snippet) =>
{
    if (string.IsNullOrEmpty(snippet.Language) || string.IsNullOrEmpty(snippet.Code))
    {
        return Results.BadRequest("Language and Code are required.");
    }

    snippet.Id = snippets.Count > 0 ? snippets.Max(s => s.Id) + 1 : 1;
    snippets.Add(snippet);

    return Results.Created($"/snippets/{snippet.Id}", snippet);
});


//Test in postman: POST http://localhost:0000/snippets select body 
// {
//     "language": "C#",
//     "code": "Console.WriteLine(\"My name is Hannah\");"
// }

app.Run();
