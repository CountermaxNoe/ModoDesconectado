using DbPersonasDesconectado.ViewModels;
using System;
using System.Collections.Generic;

namespace DbPersonasDesconectado.Models;

public partial class Personas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public Sexo Genero { get; set; }
}
