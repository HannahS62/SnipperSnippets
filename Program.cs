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

//GET with id
app.MapGet("/snippets/{id}", (int id) =>
{
    var snippet = snippets.FirstOrDefault(s => s.Id == id);
    return snippet != null ? Results.Ok(snippet) : Results.NotFound($"Snippet with ID {id} not found.");
});


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

app.Run();
