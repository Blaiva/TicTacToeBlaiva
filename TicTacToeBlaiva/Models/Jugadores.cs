using System.ComponentModel.DataAnnotations;

namespace TicTacToeBlaiva.Models;

public class Jugadores
{
    [Key]
    public int JugadorId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(0, int.MaxValue)]
    public int Victorias { get; set; }
}