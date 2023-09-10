using AudioPool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repositories.Contexts
{
    public class AudioPoolDbContext : DbContext
    {
        public AudioPoolDbContext(DbContextOptions<AudioPoolDbContext> options) : base(options) {}

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Song> Song { get; set; }
    }
}