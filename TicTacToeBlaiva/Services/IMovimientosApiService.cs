using TicTacToeBlaiva.DTOs;

namespace TicTacToeBlaiva.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientoAsync(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimiento(int PartidaId, string Jugador, int PosicionFila, int PosicionColumna);
}
