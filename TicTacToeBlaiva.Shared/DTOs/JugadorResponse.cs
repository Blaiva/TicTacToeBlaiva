using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBlaiva.Shared.DTOs;

public record JugadorResponse
(
    int JugadorId,
    string Nombres,
    string Email
);
