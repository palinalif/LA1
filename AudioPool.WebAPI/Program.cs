using System.Runtime.CompilerServices;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Implementations;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Implementations;
using AudioPool.Services.Interfaces;
using AudioPool.WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<ISongService, SongService>();
builder.Services.AddTransient<ISongRepository, SongRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AudioPoolDbContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("AudioPoolDbConnectionString"),
    b => b.MigrationsAssembly("AudioPool.WebAPI"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
