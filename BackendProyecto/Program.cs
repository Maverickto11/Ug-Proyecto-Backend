using BackendProyecto.Repositorio;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static ServiceCollection? service;
    static ServiceProvider? serviceProvider;
    static IRepositorioMovie? repositorioMovie;
    static IRepositorioSeries? repositorioSeries;

    public static void agregarServicios()
    {
        service = new ServiceCollection();
        service.AddScoped<IRepositorioMovie, RepositorioMovie>();
        service.AddScoped<IRepositorioSeries, RepositorioSeries>();

        service.AddDbContext<TmdbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql("Host=localhost; Database=BdPeliculas; Username=postgres; Password=12345"));
        
        serviceProvider = service.BuildServiceProvider();
        repositorioMovie = serviceProvider.GetService<IRepositorioMovie>();
        repositorioSeries = serviceProvider.GetService<IRepositorioSeries>();

    
    }
    public static async Task Main()
    {
        agregarServicios();

    }
}

