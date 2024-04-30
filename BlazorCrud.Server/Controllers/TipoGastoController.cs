using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;


namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoController : ControllerBase
    {
       
        private readonly DbreporteGastosContext _dbContext;

        public TipoGastoController(DbreporteGastosContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TipoGastoDTO>>();
            var listaTipoGastoDTO = new List<TipoGastoDTO>();

            try
            {
                foreach(var item in await _dbContext.TipoGastos.ToListAsync())
                {
                    listaTipoGastoDTO.Add(new TipoGastoDTO
                    {
                        
                        IdTipoGasto= item.IdTipoGasto,
                        Tipo=item.Tipo,

                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaTipoGastoDTO;
            }catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }

            return Ok(responseApi);
        }


    }
}
