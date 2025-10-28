namespace TicTacToeBlaiva.DTOs;

public record MovimientoResponse(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
);
