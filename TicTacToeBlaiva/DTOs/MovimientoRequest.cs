namespace TicTacToeBlaiva.DTOs;

public record MovimientoRequest(
     int PartidaId,
     string Jugador,
     int PosicionFila,
     int PosicionColumna 
);
