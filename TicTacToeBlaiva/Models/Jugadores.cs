using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeBlaiva.Models;

public class Jugadores
{
    [Key]
    public int JugadorId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombres { get; set; } = null!;

    [Range(0, int.MaxValue)]
    public int Victorias { get; set; }
    public int Derrotas { get; set; }
    public int Empates { get; set; }

    [InverseProperty(nameof(Models.Movimientos.Jugador))]
    public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();
}