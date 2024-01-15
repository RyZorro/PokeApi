using PokemonPokedex.Application.DTOs;
using PokemonPokedex.Application.Mapper;
using PokemonPokedex.Application.Services;
using PokemonPokedex.Domain.Entities;
using PokemonPokedex.Infrastructure.ExternalService;
using PokemonPokedex.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Dependency Injection Declarations
builder.Services.AddSingleton<IHttpGetClient, HttpClientWrapper>();
builder.Services.AddSingleton<IPokeApi, PokeApiRepsoitory>();
builder.Services.AddSingleton<IMapper<Pokemon, PokemonDTO>, PokemonMapper>();
builder.Services.AddSingleton<IPokemonWrapper<PokemonDTO>, PokemonWrapper>();
builder.Services.AddSingleton<IPokemonSearchService, PokemonSearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
