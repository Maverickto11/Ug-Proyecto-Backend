using BackendProyecto.Repositorio;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        }); builder.Services.AddScoped<IRepositorioMovie, RepositorioMovie>();
           

builder.Services.AddDbContext<TmdbContext>(opciones =>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios
builder.Services.AddScoped<IRepositorioMovie, RepositorioMovie>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
//Series
builder.Services.AddScoped<IRepositorioSeries, RepositorioSeries>();
builder.Services.AddScoped<ISeriesGenreRepository, SeriesGenreRepository>();
// Registrar servicios
builder.Services.AddScoped<IGenreService, GenreService>();

//Login
builder.Services.AddScoped<ILoginRepositoriy, LoginRepositoriy>();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(c =>


{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Biblioteca", Version = "v1" });
});

builder.Services.AddCors(opctions =>
{
    opctions.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Biblioteca v1");
        c.RoutePrefix = string.Empty; // Para que Swagger UI esté disponible en la raíz (https://localhost:7215/)
    });
}

app.UseHttpsRedirection();
app.UseCors("NuevaPolitica");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Asegúrate de tener este mapeo
app.MapRazorPages();

app.Run();

