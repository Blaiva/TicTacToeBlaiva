using TicTacToeBlaiva.DTOs;

namespace TicTacToeBlaiva.Services;

public interface IJugadoresApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
    Task<Resource<JugadorResponse>> GetJugadoresAsync(int JugadorId);
    Task<Resource<JugadorResponse>> PostJugadores(string nombre, string email);
    Task<Resource<JugadorResponse>> PutJugadores(int juagdorId, string nombre, string email);
}
