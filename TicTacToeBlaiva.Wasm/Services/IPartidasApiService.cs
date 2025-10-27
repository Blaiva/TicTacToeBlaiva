using TicTacToeBlaiva.Shared;
using TicTacToeBlaiva.Shared.DTOs;

namespace TicTacToeBlaiva.Wasm.Services;

public interface IPartidasApiService
{
    Task<Resource<List<PartidaResponse>>> GetPartidasAsync();
    Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidaResponse>> PostPartida(int jugador1, int jugador2);
}
