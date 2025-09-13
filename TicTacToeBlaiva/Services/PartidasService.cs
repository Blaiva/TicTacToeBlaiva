using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TicTacToeBlaiva.DAL;
using TicTacToeBlaiva.Models;

namespace TicTacToeBlaiva.Services;

public class PartidasService (IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int partidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.AnyAsync(p => p.PartidaId == partidaId);
    }

    public async Task<bool> Insertar(Partidas partida)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Partidas.Add(partida);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Partidas partida)
    {
        if (!await Existe(partida.PartidaId) && partida.Jugador1Id != partida.Jugador2Id)
            return await Insertar(partida);
        else
            return false;
    }

    public async Task<bool> Modificar(Partidas partida)
    {
        if(partida.Jugador1Id != partida.Jugador2Id && (partida.GanadorId == partida.Jugador1Id || partida.GanadorId == partida.Jugador2Id) && (partida.TurnoJugadorId == partida.Jugador1Id || partida.TurnoJugadorId == partida.Jugador2Id))
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(partida);
            return await contexto.SaveChangesAsync() > 0;
        }
        else
            return false;
    }

    public async Task<bool> Eliminar(int partidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.AsNoTracking().Where(p => p.PartidaId == partidaId).ExecuteDeleteAsync()>0;
    }

    public async Task<Partidas?> Buscar(int partidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.FirstOrDefaultAsync(j => j.PartidaId == partidaId);
    }

    public async Task<List<Partidas>> Listar(Expression<Func<Partidas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.Where(criterio).AsNoTracking().ToListAsync();
    }
}
