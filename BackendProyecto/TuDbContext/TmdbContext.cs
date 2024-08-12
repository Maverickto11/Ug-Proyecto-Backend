using BackendProyecto.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BackendProyecto.TuDbContext
{
    public class TmdbContext : DbContext
    {

         public TmdbContext(DbContextOptions<TmdbContext> options)
           : base(options)
         {
         }
         public DbSet<Movie> Movies { get; set; }
         public DbSet<Genre> Genres { get; set; }
         public DbSet<MovieGenre> MovieGenres { get; set; }
         public DbSet<SeriesGenre> SeriesGenres { get; set; }
         public DbSet<Usuario> Usuarios { get; set; }
         public DbSet<Pelicula> Peliculas { get; set; }
         public DbSet<AutenticacionRespuesta> AutenticacionRespuestas { get; set; }
         public DbSet<Series> Series { get; set; }
         public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<SeriesGenre>()
                .HasKey(sg => new { sg.SeriesId, sg.GenreId });

             modelBuilder.Entity<MovieGenre>()
                 .HasOne(mg => mg.Movie)
                 .WithMany(m => m.MovieGenres)  
                 .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<SeriesGenre>()
                .HasOne(sg => sg.Series)
                .WithMany(s => s.SeriesGenres)
                .HasForeignKey(sg => sg.SeriesId);


             modelBuilder.Entity<MovieGenre>()
                 .HasOne(mg => mg.Genre)
                 .WithMany(g => g.MovieGenres)
                 .HasForeignKey(mg => mg.GenreId)
                 .OnDelete(DeleteBehavior.SetNull); // Permitir nulo al eliminar

            modelBuilder.Entity<SeriesGenre>()
                 .HasOne(sg => sg.Genre)
                 .WithMany(m => m.SeriesGenres)
                 .HasForeignKey(sg => sg.GenreId)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pelicula>();
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Ignore<AutenticacionRespuesta>();



            // Aplica la configuración para MovieGenre
            //modelBuilder.ApplyConfiguration(new MovieGenre.MovieGenreConfiguration());
        }



        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseNpgsql("Host=localhost;Database=BdPeliculas;Username=postgres;Password=12345");
         }
         /*

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<MovieGenre>()
                 .HasKey(mg => new { mg.MovieId, mg.GenreId });

             modelBuilder.Entity<MovieGenre>()
                 .HasOne(mg => mg.Movie)
                 .WithMany(m => m.MovieGenres)
                 .HasForeignKey(mg => mg.MovieId);

             modelBuilder.Entity<MovieGenre>()
                 .HasOne(mg => mg.Genre)
                 .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);
         }*/




    }
}
