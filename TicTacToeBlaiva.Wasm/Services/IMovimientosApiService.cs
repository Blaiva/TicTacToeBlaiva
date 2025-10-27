using TicTacToeBlaiva.Shared;
using TicTacToeBlaiva.Shared.DTOs;

namespace TicTacToeBlaiva.Wasm.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila, int posicionColumna);
}
