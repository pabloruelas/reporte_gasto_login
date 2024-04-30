using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class TipoGasto
{
    public int IdTipoGasto { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<GastoGeneral> GastoGenerals { get; set; } = new List<GastoGeneral>();
}
