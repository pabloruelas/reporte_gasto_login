using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared
{
    public class GastoGeneralDTO
    {
        public int IdGasto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string? ConceptoGasto { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "El campo {0} es requerido.")]
        public int IdTipoGasto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public double Monto { get; set; }

        public DateOnly FechaGasto { get; set; }

        public TipoGastoDTO? TipoGasto { get; set;}

    }
}
