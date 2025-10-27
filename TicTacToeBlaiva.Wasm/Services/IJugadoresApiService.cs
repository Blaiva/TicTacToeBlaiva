using TicTacToeBlaiva.Shared;
using TicTacToeBlaiva.Shared.DTOs;

namespace TicTacToeBlaiva.Wasm.Services;

public interface IJugadoresApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
    Task<Resource<JugadorResponse>> GetJugadorAsync(int jugadorId);
    Task<Resource<JugadorResponse>> PostJugador(string nombres, string email);
}
