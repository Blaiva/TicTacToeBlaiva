using TicTacToeBlaiva.Models;
using Microsoft.EntityFrameworkCore;

namespace TicTacToeBlaiva.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Jugadores> Jugadores { get; set; }
}
