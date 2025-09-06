using System.ComponentModel.DataAnnotations;


namespace RegistroJugadores.Models
{
    public class Jugadores
    {
        [Key]
        public int JugadorId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Partidas { get; set; }

    }
}
