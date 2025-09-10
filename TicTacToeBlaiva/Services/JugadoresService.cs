using TicTacToeBlaiva.DAL;
using TicTacToeBlaiva.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TicTacToeBlaiva.Services;
public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.AnyAsync(j => j.JugadorId == jugadorId);
    }

    public async Task<bool> ExisteNombres(string nombres)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.AnyAsync(j => j.Nombres.Equals(nombres));
    }

    public async Task<bool> Insertar(Jugadores jugador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Jugadores.Add(jugador);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Jugadores jugador)
    {
        if(!await Existe(jugador.JugadorId) && !await ExisteNombres(jugador.Nombres))
        {
            return await Insertar(jugador);
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> Modificar(Jugadores jugador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(jugador);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.AsNoTracking().Where(j => j.JugadorId == jugadorId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Jugadores?> Buscar(int jugadorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.FirstOrDefaultAsync(j=>j.JugadorId==jugadorId);
    }

    public async Task<List<Jugadores>> Listar(Expression<Func<Jugadores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.Where(criterio).AsNoTracking().ToListAsync();
    }
}
