using System;
using System.Collections.Generic;

namespace DBToaruModoDesconectado.Models;

public partial class Espers
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apodo { get; set; } = null!;

    public int Nivel { get; set; }

    public string Habilidad { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string ImagenUrl { get; set; } = null!;
}
