using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class GastoGeneral
{
    public int IdGasto { get; set; }

    public string? ConceptoGasto { get; set; }

    public int IdTipoGasto { get; set; }

    public double Monto { get; set; }

    public DateOnly FechaGasto { get; set; }

    public virtual TipoGasto IdTipoGastoNavigation { get; set; } = null!;
}
