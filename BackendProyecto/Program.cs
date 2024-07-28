using BackendProyecto.Repositorio;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static ServiceCollection? service;
    static ServiceProvider? serviceProvider;
    static IRepositorioMovie? repositorioMovie;

    public static void agregarServicios()
    {
        service = new ServiceCollection();
        service.AddScoped<IRepositorioMovie, RepositorioMovie>();

        service.AddDbContext<TmdbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql("Host=localhost; Database=BdPeliculas; Username=postgres; Password=12345"));

        serviceProvider = service.BuildServiceProvider();
        repositorioMovie = serviceProvider.GetService<IRepositorioMovie>();

    
    }
    public static async Task Main()
    {
        agregarServicios();

    }
}

